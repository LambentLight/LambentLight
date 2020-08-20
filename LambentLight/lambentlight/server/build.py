import logging
import os
import os.path
import shutil
import tempfile

from .arguments import arguments
from .checks import is_ubuntu, is_windows
from .compression import extract

import aiohttp

logger = logging.getLogger("lambentlight")


class Build:
    """
    The information of a CFX Build.
    """
    builds_dir: str = os.path.join(arguments.work_dir, "builds")

    def __init__(self, *, folder: str = None, download: str = None, name: str = None):
        # If the parameters are mixed in an invalid format, raise an exception
        if folder and (download or name):
            raise ValueError("You can't specify a Download or ID in combination with a Folder.")

        # Otherwise, store the information in the correct format
        if folder:
            self.folder = folder
            self.name = os.path.dirname(folder)
            self.url = None
        else:
            self.folder = os.path.join(arguments.work_dir, "builds", name)
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
        if is_windows:
            return os.path.join(self.folder, "FXServer.exe")
        elif is_ubuntu:
            return os.path.join(self.folder, "run.sh")
        else:
            return None

    @property
    def citizen_dir(self):
        """
        Returns the value of the citizen subdirectory.
        """
        return os.path.join(self.folder, "citizen")

    async def download(self, session: aiohttp.ClientSession):
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
        async with session.get(self.url) as resp:
            with open(temp_file, "wb") as file:
                while True:
                    chunk = await resp.content.read(1024 * 1024)
                    if not chunk:
                        break
                    file.write(chunk)
        # Time to extract it!
        # Make the paths and extract it
        ext_path = os.path.join(tempfile.gettempdir(), "lambentlight", "builds", self.name)
        extracted = extract(temp_file, ext_path)
        # If we were unable to extract the file, log a message
        if not extracted:
            logger.error(f"Installation of Build {self.name} failed: Unable to Extract")
            return False
        # Finish by moving the directory to the target and notifying it
        os.makedirs(self.builds_dir)
        shutil.move(ext_path, self.builds_dir)
        return True
