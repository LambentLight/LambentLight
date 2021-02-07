import json
import logging
import os
import os.path as path
from typing import Union

import aiofiles
import aiohttp
from git import Repo

import lambentlight.server as server


logger = logging.getLogger("lambentlight")


class Manager:
    """
    The main manager of LambentLight.
    """
    builds_dir: str = os.path.join(server.arguments.work_dir, "builds")

    def __init__(self):
        self.session = None
        self.config = server.default_config
        self.builds = []
        self.folders = []
        self.ws_clients = []

    async def initialize(self):
        """
        Initializes the basics of the Manager.
        """
        # Format the path of the configuration file
        config = os.path.join(server.arguments.work_dir, "config.json")

        # If the configuration file is missing, raise an exception
        if not path.isfile(config):
            logger.error("Configuration file is missing!")
            logger.error("Please run LambentLight with the --init parameter to create it")
            return False

        # Otherwise, just load it
        async with aiofiles.open(config) as file:
            loaded = json.loads(await file.read())
            self.config = {}
            for key, value in server.default_config.items():
                if key in loaded:
                    self.config[key] = loaded[key]
                else:
                    self.config[key] = value
        logger.info(f"Loaded configuration from {config}")

        # Create the Client Session
        self.session = aiohttp.ClientSession()
        # And fetch the information required by the manager
        await self.update_builds()
        await self.update_folders()

        # Then, check if one of the data folders should be started on boot
        for folder in self.folders:
            # If this one does not, continue to the next one
            if not folder.config["auto_start"]:
                continue
            # Otherwise, try to get the build required or use the latest one
            name = folder.config["auto_start_build"]
            if name:
                found = [x for x in self.builds if x.name == name]
                if not found:
                    logger.error(f"Unable to find Build {name} to Auto Start Folder {folder.name}")
                    continue
                build = found[0]
            else:
                build = self.builds[0]

            # Then, try to start the server
            if not await folder.start(build):
                logger.error(f"Unable to automatically start Folder {folder.name}")
                continue

        # Finally, tell the main script that we finished the init
        return True

    async def save_settings(self):
        """
        Saves the settings.
        """
        async with aiofiles.open(os.path.join(server.arguments.work_dir, "config.json"), "w") as file:
            text = json.dumps(self.config, indent=4) + "\n"
            await file.write(text)
            logger.info("Settings have been saved")

    async def close(self):
        """
        Stops all of the servers and web sessions in use.
        """
        logger.info("Stopping LambentLight")
        # Close the session used for aiohttp web requests
        await self.session.close()
        # And disconnect all of the WS Clients
        for ws in self.ws_clients:
            if not ws.closed:
                await ws.close(code=aiohttp.WSCloseCode.GOING_AWAY,
                               message="LambentLight is Closing")

    async def create_folder(self, name: str, clone: bool):
        """
        Creates a new Data Folder.
        """
        path = os.path.join(server.arguments.work_dir, "data", name)

        # Create the folder or clone the repository
        if clone:
            # From https://gitpython.readthedocs.io/en/stable/intro.html:
            # GitPython is not suited for long-running processes (like daemons) as
            # it tends to leak system resources. It was written in a time where destructors
            # (as implemented in the __del__ method) still ran deterministically.
            # In case you still want to use it in such a context, you will want to search the
            # codebase for __del__ implementations and call these yourself when you see fit.
            repo = Repo.clone_from("https://github.com/LambentLight/ServerData.git", path)
            del repo
        else:
            os.makedirs(path, exist_ok=True)

        # Then, create an empty configuration file
        async with aiofiles.open(os.path.join(path, "lambentlight.json"), "w") as file:
            await file.write("{\n}\n")
        # Now, update the list of folders
        await self.update_folders()
        # And return the one with the same exact name
        # TODO: Make this safer
        return [x for x in self.folders if x.name == name][0]

    async def update_builds(self):
        """
        Updates the list of known CFX Builds.
        """
        # Start with the remote builds from the URLs
        remote = []
        for url in self.config["builds"]:
            logger.info(f"Fetching builds from '{url}'")
            # Try to make the request
            async with self.session.get(url) as resp:
                # Discard any code 200 errors
                if resp.status != 200:
                    logger.error(f"Unable to fetch builds from '{url}': Code {resp.status}")
                    continue
                # And try to convert it to a dict from JSON
                try:
                    new = await resp.json(content_type=None)
                except json.JSONDecodeError as e:
                    logger.error(f"Unable to parse builds from '{url}': {e}")
                    continue
                # If no builds are present in the json, skip it
                if "builds" not in new:
                    logger.error(f"Response from {url} does not has any builds.")
                    continue

                # Now, time to add the builds one by one
                for build in new["builds"]:
                    # If one of the parts is missing, log it and continue
                    if "name" not in build:
                        logger.error("Name of Build is missing.")
                        continue
                    elif "download" not in build:
                        logger.error("Download URL of Build is missing.")
                        continue
                    elif "target" not in build:
                        logger.error("Target Operating System of Build was not found.")
                        continue

                    # If we got here, create a new one if it matches the os
                    if (build["target"] == 0 and server.is_windows) or (build["target"] == 1 and server.is_ubuntu):
                        remote.append(server.Build(name=build["name"], download=build["download"]))

        # Now is time for the local builds
        local = []
        if os.path.isdir(self.builds_dir):
            # Iterate over the entries in the directory
            for entry in os.scandir(self.builds_dir):
                # If the entry is not a directory, skip it
                if not entry.is_dir():
                    continue
                # If there is no remote build that matches the name, add it as a local build
                if not any(x for x in remote if x.name == entry.name):
                    local.append(server.Build(folder=entry))

        # At this point, replace the builds and notify it
        self.builds = remote + local
        logger.info(f"Builds have been updated (Total: {len(self.builds)})")

    async def update_folders(self):
        """
        Updates the list of Data Folders.
        """
        # Get the subdirectories of data and save them as Data Folders
        dpath = os.path.join(server.arguments.work_dir, "data")
        if os.path.isdir(dpath):
            local = [server.DataFolder(x, True) for x in os.scandir(dpath) if x.is_dir()]
        else:
            logger.warning("Directory with Data Folder does not exists, skipping...")
            local = []
        logger.info(f"Data Folders have been updated (Total: {len(local)})")
        self.folders = local

    async def remove(self, obj: Union[server.DataFolder, server.Build], *, stop=True):
        """
        Removes a Data Folder or Build.
        """
        # If is on none of the lists, return
        if obj not in self.folders and obj not in self.builds:
            return False

        # If is a Data Folder
        if isinstance(obj, server.DataFolder):
            # If there is a server running, stop it if required
            # Raise an exception otherwise
            if obj.is_running:
                if not stop:
                    raise server.ServerRunningException()
                await obj.stop(terminate=False)
            # And then delete it
            self.folders.remove(obj)
            return True
        # If is a Build
        elif isinstance(obj, server.Build):
            # Try to find servers running with the Data Folder
            servers = [x for x in server.manager.folders if x.build == obj]
            if servers:
                if not stop:
                    raise server.ServerRunningException()
                for srv in servers:
                    await srv.stop()
            # If the build is installed, delete it
            if obj.is_ready:
                await obj.delete()
            # And then remove it
            self.builds.remove(obj)
        # If we got here, say that we were unable to delete it
        return False

    async def send_data(self, event: str, data):
        """
        Sends some data to the connected Clients via WebSockets.
        """
        for ws in self.ws_clients:
            data = {
                "e": event,
                "d": data
            }
            await ws.send_json(data)

    async def process(self):
        """
        Processes checks for the Manager.
        """
        await self.restart_on_crash()

    async def restart_on_crash(self):
        """
        Checks if the servers have exited with non zero codes and restart them if they do.
        """
        for folder in self.folders:
            # If there is no process or there is one and is running, continue
            if folder.process is None or folder.is_running:
                continue
            # If we got here, the process is no longer running
            # If the exit code is zero, notify it and continue
            code = folder.process.returncode
            if code == 0:
                logger.info(f"Server {folder.name} exited with Code {code}")
                await folder.stop()
            # Otherwise, restart the process
            else:
                logger.warning(f"Restarting Server {folder.name} because it exited with Code {code}")
                await folder.start(folder.build, terminate=True)


manager = Manager()
