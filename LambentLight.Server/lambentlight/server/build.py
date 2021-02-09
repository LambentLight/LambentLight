import contextlib
import logging
import os
import os.path
import shutil
import tempfile

import aiofiles
import aiofiles.os

import lambentlight.server as server

logger = logging.getLogger("lambentlight")


class Build:
    """
    The information of a CFX Build.
    """
    def __init__(self, manager, *, folder: str = None, download: str = None, name: str = None):
        self.manager = manager

        # If the parameters are mixed in an invalid format, raise an exception
        if folder and (download or name):
            raise ValueError("You can't specify a Download or ID in combination with a Folder.")

        # Otherwise, store the information in the correct format
        if folder:
            self.folder = folder
            self.name = os.path.basename(folder)
            self.url = None
        else:
            self.folder = os.path.join(manager.dir, name)
            self.name = name
            self.url = download

    def __iter__(self):
        yield "name", self.name
        yield "url", self.url,
        yield "is_ready", self.is_ready

    @property
    def is_ready(self):
        """
        Checks if the Build is ready to be used.
        """
        return os.path.isfile(self.executable)

    @property
    def executable(self):
        """
        Returns the name of the server executable.
        """
        if server.is_windows:
            return os.path.join(self.folder, "FXServer.exe")
        elif server.is_ubuntu:
            return os.path.join(self.folder, "run.sh")
        else:
            return None

    @property
    def citizen_dir(self):
        """
        Returns the value of the citizen subdirectory.
        """
        return os.path.join(self.folder, "citizen")

    async def download(self):
        """
        Downloads the Build.

        If is already installed, it will be removed and re-downloaded.
        """
        # If there is no download link, return
        if not self.url:
            return False

        # Otherwise, make the required paths and create them if needed
        temp_dir = os.path.join(tempfile.gettempdir(), "lambentlight", "builds")
        os.makedirs(temp_dir, exist_ok=True)
        temp_file = os.path.join(temp_dir, self.name + "_dl")
        logger.info(f"Downloading build {self.name} from {self.url} to {temp_file}")
        # Then, request it and save it in chunks
        async with self.manager.session.get(self.url) as resp:
            async with aiofiles.open(temp_file, "wb") as file:
                while True:
                    chunk = await resp.content.read(1024 * 1024)
                    if not chunk:
                        break
                    await file.write(chunk)
        # Time to extract it!
        # Make the paths and extract it
        ext_path = os.path.join(tempfile.gettempdir(), "lambentlight", "builds", self.name)
        extracted = await server.extract(temp_file, ext_path)
        # If we were unable to extract the file, log a message
        if not extracted:
            logger.error(f"Installation of Build {self.name} failed: Unable to Extract")
            return False
        # If the target folder exists, remove it
        target = os.path.join(self.manager.builds_dir, self.name)
        if os.path.isdir(target):
            server.rmtree(target)
        # Finish by moving the directory to the target and notifying it
        os.makedirs(self.manager.builds_dir, exist_ok=True)
        shutil.move(ext_path, self.manager.builds_dir)
        return True

    async def delete(self):
        """
        Deletes the Build.
        """
        with contextlib.suppress(FileNotFoundError):
            server.rmtree(self.folder)
