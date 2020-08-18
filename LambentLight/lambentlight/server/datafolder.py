import json
import logging
import os.path

logger = logging.getLogger("lambentlight")
default = {
    "token_cfx": "",
    "token_steam": "",
    "game": "gtav"
}


class DataFolder:
    """
    Represents an independent folder with Resources.
    """
    def __init__(self, path: str, local: bool):
        self.path = os.path.abspath(path)
        self.name = os.path.basename(self.path)
        self.local = local
        self.config = {}
        self.reload_configuration()

    @property
    def can_be_used(self):
        """
        Checks if the Data Folder can be used for a server.
        """
        return os.path.isdir(self.path)

    def reload_configuration(self):
        """
        Reloads the configuration specific to this Data Folder.
        """
        path = os.path.join(self.path, "lambentlight.json")

        # If the file is there, load it
        if os.path.isfile(path):
            newconfig = {}
            with open(path) as file:
                loaded = json.load(file)
                for key, item in default.items():
                    if key in loaded:
                        newconfig[key] = loaded[key]
                    else:
                        newconfig[key] = item
                self.config = newconfig
        # Otherwise, use the default values
        else:
            logger.warning(f"Data Folder {self.name} does not has a LambentLight Configuration File")
            self.config = default
