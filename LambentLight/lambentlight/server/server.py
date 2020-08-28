import asyncio
import locale
import logging
import signal
import subprocess
from asyncio import create_subprocess_exec
from asyncio.subprocess import PIPE

import lambentlight.server as server

logger = logging.getLogger("lambentlight")


class Server:
    """
    Represents a server currently running.
    """
    def __init__(self, build: server.Build, folder: server.DataFolder):
        self.build = build
        self.folder = folder
        self.process = None

    def __iter__(self):
        yield "is_running", self.is_running
        yield "pid", self.process.pid if self.is_running else 0
        yield "build", dict(self.build)
        yield "folder", dict(self.folder)

    @property
    def is_running(self):
        """
        Checks if the server is running or not.
        """
        return self.process is not None and self.process.returncode is None

    @property
    def token(self):
        """
        Gets a CFX Token that can be used to start the server.
        """
        # Try to get the token from the Data Folder and Manager config
        # If it was not possible, return None
        if self.folder.config["token_cfx"]:
            return self.folder.config["token_cfx"]
        elif server.manager.config["token_cfx"]:
            logger.warning(f"Using global CFX Token for Data Folder {self.folder.name}")
            return server.manager.config["token_cfx"]
        else:
            logger.error(f"No CFX Token is available for Data Folder {self.folder.name}")
            return None

    async def stop(self, terminate=False):
        """
        Stops or Terminates the game server.
        """
        # If the process is not running, return
        if not self.process or self.process.returncode is not None:
            return

        # If we want to terminate it, do it
        if terminate:
            self.process.terminate()
        # Otherwise, send the interrupt
        else:
            self.process.send_signal(signal.CTRL_BREAK_EVENT if server.is_windows else signal.SIGINT)
        # And wait for the process to exit
        await self.process.wait()
        self.process = None

    async def start(self, terminate=False):
        """
        Starts or Restarts the game server.
        """
        # Make sure to stop the server
        await self.stop(terminate)

        # If the build is not ready to be used, download it
        if not self.build.is_ready:
            if not await self.build.download(server.manager.session):
                logger.error("The server can't be started")
                return False
        # Make sure that the Data Folder is there
        if not self.folder.can_be_used:
            logger.error(f"Unable to start the server because the Data Folder is not present")
            return False
        # Get the token and return if is invalid
        token = self.token
        if not token:
            logger.info(f"Unable to start {self.folder.name}: Invalid Token")
            return False

        # Format the launch parameters
        params = [
            "+set", "citizen_dir", f"\"{self.build.citizen_dir}\"",
            "+set", "sv_licenseKey", token,
            "+set", "gamename", self.folder.config["game"]
        ]
        # And add the exec arguments
        for config in self.folder.config["exec"]:
            params.append("+exec")
            params.append(config)

        # Select the correct creation flags
        flags = subprocess.CREATE_NEW_PROCESS_GROUP if server.is_windows else 0

        # Then, start the process and save it
        process = await create_subprocess_exec(self.build.executable, *params, cwd=self.folder.path,
                                               stdin=PIPE, stdout=PIPE, stderr=PIPE, creationflags=flags)
        self.process = process
        asyncio.create_task(self.read_process_stdout())
        return True

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
                "folder": self.folder.name,
                "message": line.decode(locale.getpreferredencoding(False)).strip("\n")
            }
            await server.manager.send_data("console", data)
