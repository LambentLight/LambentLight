import asyncio
import json
import locale
import logging
import os.path
import signal
import subprocess
from asyncio.subprocess import create_subprocess_exec, PIPE

import psutil

import lambentlight.server as server


logger = logging.getLogger("lambentlight")
default = {
    "auto_start": False,
    "auto_start_build": "",
    "token_cfx": "",
    "token_steam": "",
    "game": "gtav",
    "exec": ["server.cfg"]
}


def get_resources_in_dir(path, datafolder):
    """
    Gets the resources installed in the folder.
    """
    # Iterate over the items inside of the resources directory
    for found in os.scandir(os.path.join(path)):
        # If is not a directory, continue to the next iteration
        if not found.is_dir():
            continue
        # Get the name of the directory
        name = os.path.basename(found.path)
        # If is called .git, skip it (just in case)
        if name == ".git":
            continue
        # If it has [], is a subdirectory so also fetch those
        if name.startswith("[") and name.endswith("]"):
            yield from get_resources_in_dir(found.path, datafolder)
            continue
        # Otherwise, yield a resource
        yield server.LocalResource(datafolder, found.path)


class DataFolder:
    """
    Represents an independent folder with Resources.
    """
    def __init__(self, path: str, local: bool):
        self.path = os.path.abspath(path)
        self.name = os.path.basename(self.path)
        self.local = local
        self.config = {}
        self.build = None
        self.process = None
        self.process_info = None
        self.reload_configuration()

    def __iter__(self):
        yield "name", self.name
        yield "path", self.path

    @property
    def proc_info(self):
        """
        The information of the process.
        """
        if self.is_running:
            with self.process_info.oneshot():
                return {
                    "pid": self.process.pid,
                    "cpu": self.process_info.cpu_percent(),
                    "mem": self.process_info.memory_info().rss,
                    "build": dict(self.build)
                }
        else:
            return None

    @property
    def token(self):
        """
        Gets a CFX Token that can be used to start the server.
        """
        # Try to get the token from the Data Folder and Manager config
        # If it was not possible, return None
        if self.config["token_cfx"]:
            return self.config["token_cfx"]
        elif server.manager.config["token_cfx"]:
            logger.warning(f"Using global CFX Token for Data Folder {self.name}")
            return server.manager.config["token_cfx"]
        else:
            logger.error(f"No CFX Token is available for Data Folder {self.name}")
            return None

    @property
    def is_running(self):
        """
        Checks if the server is running or not.
        """
        return self.process is not None and self.process.returncode is None

    @property
    def can_be_used(self):
        """
        Checks if the Data Folder can be used for a server.
        """
        return os.path.isdir(self.path)

    @property
    def resources(self):
        """
        Returns an iterator with the list of Local Resources.
        """
        yield from get_resources_in_dir(os.path.join(self.path, "resources"), self)

    async def start(self, build, terminate=False):
        """
        Starts or Restarts the game server.
        """
        # Make sure to stop the server
        await self.stop(terminate)

        # If the build is not ready to be used, download it
        if not build.is_ready:
            if not await build.download(server.manager.session):
                logger.error("The server can't be started")
                return False
        # Make sure that the Data Folder is there
        if not self.can_be_used:
            logger.error(f"Unable to start the server because the Data Folder is not present")
            return False
        # Get the token and return if is invalid
        token = self.token
        if not token:
            logger.info(f"Unable to start {self.name}: Invalid Token")
            return False

        # Format the launch parameters
        params = [
            "+set", "citizen_dir", f"\"{build.citizen_dir}\"",
            "+set", "sv_licenseKey", token,
            "+set", "gamename", self.config["game"]
        ]
        # And add the exec arguments
        for config in self.config["exec"]:
            params.append("+exec")
            params.append(config)

        # Select the correct creation flags
        flags = subprocess.CREATE_NEW_PROCESS_GROUP if server.is_windows else 0

        # Then, start the process and save it
        process = await create_subprocess_exec(build.executable, *params, cwd=self.path,
                                               stdin=PIPE, stdout=PIPE, stderr=PIPE, creationflags=flags)
        self.process = process
        self.build = build
        self.process_info = psutil.Process(process.pid)
        self.process_info.cpu_percent()
        asyncio.create_task(self.read_process_stdout())
        logger.info(f"Started Data Folder {self.name} with Build {build.name}")
        return True

    async def stop(self, terminate=False, wait=True):
        """
        Stops or Terminates the game server.
        """
        # If the process is running
        if self.is_running:
            # Stop the process by force or gracefully
            if terminate:
                self.process.terminate()
            else:
                self.process.send_signal(signal.CTRL_BREAK_EVENT if server.is_windows else signal.SIGINT)
            # And wait for it to be closed (if required)
            if wait:
                await self.process.wait()
        # Finally, set the process and build to None
        self.process = None
        self.build = None
        self.process_info = None

    def reload_configuration(self):
        """
        Reloads the configuration specific to this Data Folder.
        """
        path = os.path.join(self.path, "lambentlight.json")

        # If the file is there, load it
        if os.path.isfile(path):
            newconfig = {}
            with open(path) as file:
                loaded = json.load(file)
                for key, item in default.items():
                    if key in loaded:
                        newconfig[key] = loaded[key]
                    else:
                        newconfig[key] = item
                self.config = newconfig
        # Otherwise, use the default values
        else:
            logger.warning(f"Data Folder {self.name} does not has a LambentLight Configuration File")
            self.config = default

    async def read_process_stdout(self):
        """
        Reads the STDOUT of the process.
        """
        # If there is no process or it has exited, return
        if not self.is_running:
            return

        # Otherwise, start sending the lines to the WS Clients
        async for line in self.process.stdout:
            data = {
                "folder": self.name,
                "message": line.decode(locale.getpreferredencoding(False)).strip("\n")
            }
            await server.manager.send_data("console", data)
