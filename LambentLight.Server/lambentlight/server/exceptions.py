class LambentLightServerException(Exception):
    """
    Base Exception for the LambentLight Server.
    """


class ServerRunningException(Exception):
    """
    Exception raised when an operation can't be completed because there is a server running.
    """
