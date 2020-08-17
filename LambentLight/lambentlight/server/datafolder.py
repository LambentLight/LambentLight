import os.path


class DataFolder:
    """
    Represents an independent folder with Resources.
    """
    def __init__(self, path: str, local: bool):
        self.path = os.path.abspath(path)
        self.name = os.path.basename(self.path)
        self.local = local

    @property
    def can_be_used(self):
        """
        Checks if the Data Folder can be used for a server.
        """
        return os.path.isdir(self.path)
