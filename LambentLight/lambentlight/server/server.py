import logging
import subprocess

from .build import Build
from .datafolder import DataFolder
from .manager import manager

logger = logging.getLogger("lambentlight")


class Server:
    """
    Represents a server currently running.
    """
    def __init__(self, build: Build, folder: DataFolder, process: subprocess.Popen):
        self.build = build
        self.folder = folder
        self.process = process

    @staticmethod
    async def start(build: Build, folder: DataFolder):
        """
        Starts a new CFX Server.
        """
        # Try to get the token from the Data Folder and Manager config
        # If it was not possible, return
        if folder.config["token_cfx"]:
            token = folder.config["token_cfx"]
        elif manager.config["token_cfx"]:
            logger.warning(f"Using global CFX Token for Data Folder {folder.name}")
            token = manager.config["token_cfx"]
        else:
            logger.error(f"No CFX Token is available for starting {folder.name}")
            return None

        # If the build is not ready to be used, download it
        if not build.is_ready:
            if not await build.download(manager.session):
                logger.error("The server can't be started")
                return None

        # Make sure that the Data Folder is there
        if not folder.can_be_used:
            logger.error(f"Unable to start the server because the Data Folder is not present")
            return None

        # Format the launch parameters
        params = [
            build.executable,
            "+set", "citizen_dir", f"\"{build.citizen_dir}\"",
            "+set", "sv_licenseKey", token,
            "+set", "gamename", folder.config["game"]
        ]
        # And add the exec arguments
        for config in folder.config["exec"]:
            params.append("+exec")
            params.append(config)
        # Then, start the process
        process = subprocess.Popen(params, stdin=subprocess.PIPE, stdout=subprocess.PIPE, stderr=subprocess.PIPE,
                                   shell=False, cwd=folder.path, universal_newlines=True)
        # And return the new server instance
        server = Server(build, folder, process)
        manager.servers.append(server)
        return server
