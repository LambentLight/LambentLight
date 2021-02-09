class LambentLightServerException(Exception):
    """
    Base Exception for the LambentLight Server.
    """


class ServerRunningException(Exception):
    """
    Exception raised when an operation can't be completed because there is a server running.
    """


class MissingTokenException(LambentLightServerException):
    """
    Exception raised when the CFX Token is missing.
    """
    def __init__(self, folder):
        super().__init__(f"Folder {folder.name} has no token set.")
        self.folder = folder


class InUseException(LambentLightServerException):
    """
    Exception raised when the Build or Data Folder is being used.
    """
    def __init__(self, in_use):
        super().__init__(f"{in_use.name} is being used by a Server or Data Folder")
        self.in_use = in_use
