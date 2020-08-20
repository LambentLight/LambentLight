import logging
import signal
import subprocess

from .build import Build
from .datafolder import DataFolder
from .manager import manager

logger = logging.getLogger("lambentlight")


class Server:
    """
    Represents a server currently running.
    """
    def __init__(self, build: Build, folder: DataFolder):
        self.build = build
        self.folder = folder
        self.process = None

    def __iter__(self):
        yield "build", dict(self.build)
        yield "folder", dict(self.folder)

    @property
    async def token(self):
        """
        Gets a CFX Token that can be used to start the server.
        """
        # Try to get the token from the Data Folder and Manager config
        # If it was not possible, return None
        if self.folder.config["token_cfx"]:
            return self.folder.config["token_cfx"]
        elif manager.config["token_cfx"]:
            logger.warning(f"Using global CFX Token for Data Folder {self.folder.name}")
            return manager.config["token_cfx"]
        else:
            logger.error(f"No CFX Token is available for Data Folder {self.folder.name}")
            return None

    async def start(self, terminate=False):
        """
        Starts or Restarts the game server.
        """
        # If the server is running, stop it
        if self.process and self.process.poll() is not None:
            self.process.send_signal(signal.SIGINT)
            self.process.wait()

        # If the build is not ready to be used, download it
        if not self.build.is_ready:
            if not await self.build.download(manager.session):
                logger.error("The server can't be started")
                return False
        # Make sure that the Data Folder is there
        if not self.folder.can_be_used:
            logger.error(f"Unable to start the server because the Data Folder is not present")
            return False
        # Get the token and return if is invalid
        token = await self.token
        if not token:
            logger.info(f"Unable to start {self.folder.name}: Invalid Token")
            return False

        # Format the launch parameters
        params = [
            self.build.executable,
            "+set", "citizen_dir", f"\"{self.build.citizen_dir}\"",
            "+set", "sv_licenseKey", token,
            "+set", "gamename", self.folder.config["game"]
        ]
        # And add the exec arguments
        for config in self.folder.config["exec"]:
            params.append("+exec")
            params.append(config)

        # Then, start the process and save it
        process = subprocess.Popen(params, stdin=subprocess.PIPE, stdout=subprocess.PIPE, stderr=subprocess.PIPE,
                                   shell=False, cwd=self.folder.path, universal_newlines=True)
        self.process = process
        return True
