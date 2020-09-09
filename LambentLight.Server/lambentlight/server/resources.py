import contextlib
import os.path

import lambentlight.server as server


class LocalResource:
    """
    Represents a resource locally found in a Data Folder.
    """
    def __init__(self, folder: server.DataFolder, path: str):
        """
        Creates a new Local Resource object.
        """
        # Save the current Data Folder and resource information
        self.folder = folder
        self.path = os.path.abspath(path)
        self.name = os.path.basename(self.path)

    def __iter__(self):
        yield "name", self.name
        yield "path", self.path
        yield "manifest", self.manifest

    @property
    def manifest(self):
        """
        Gets the path of the Resource Manifest.
        """
        old_manifest = os.path.join(self.path, "fxmanifest.lua")
        new_manifest = os.path.join(self.path, "__resource.lua")
        if os.path.isfile(old_manifest):
            return old_manifest
        elif os.path.isfile(new_manifest):
            return new_manifest
        else:
            return None

    def uninstall(self):
        """
        Uninstalls the Resource from the Data Folder.
        """
        # If the folder exists, remove it
        with contextlib.suppress(FileNotFoundError):
            os.rmdir(self.path)
