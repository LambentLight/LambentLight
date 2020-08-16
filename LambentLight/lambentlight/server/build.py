import os.path

from .arguments import arguments
from .checks import is_ubuntu, is_windows


class Build:
    """
    The information of a CFX Build.
    """
    def __init__(self, *, folder: str = None, download: str = None, name: str = None):
        # If the parameters are mixed in an invalid format, raise an exception
        if folder and (download or name):
            raise ValueError("You can't specify a Download or ID in combination with a Folder.")

        # Otherwise, store the information in the correct format
        if folder:
            self.folder = folder
            self.name = os.path.dirname(folder)
            self.download = None
        else:
            self.folder = os.path.join(arguments.work_dir, "builds", name)
            self.name = name
            self.download = download

    @property
    def is_ready(self):
        """
        Checks if the Build is ready to be used.
        """
        # Check for the presence of the correct file for Windows and Linux
        if is_windows:
            return os.path.isfile(os.path.join(self.folder, "FXServer.exe"))
        elif is_ubuntu:
            return os.path.isfile(os.path.join(self.folder, "run.sh"))
        else:
            return False
