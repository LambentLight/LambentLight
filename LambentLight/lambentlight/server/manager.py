import json
import logging
import os
import os.path as path

import aiohttp

from .arguments import arguments


logger = logging.getLogger("lambentlight")
default = {
    "dl_builds": "https://raw.githubusercontent.com/LambentLight/Builds/master/builds.json"
}


class Manager:
    """
    The main manager of LambentLight.
    """
    def __init__(self):
        self.session = None
        self.config_path = path.join(arguments.work_dir, "Config.json")
        self.config = default
        self.builds = []

    async def initialize(self):
        """
        Initializes the basics of the Manager.
        """
        # Create the Client Session
        self.session = aiohttp.ClientSession()
        # If the configuration exists, load it
        if path.isfile(self.config_path):
            with open(self.config_path) as file:
                self.config = default.update(json.load(file))
            logger.info(f"Loaded configuration from {self.config_path}")
        # Otherwise, write the default values
        else:
            os.makedirs(arguments.work_dir, exist_ok=True)
            with open(self.config_path, "w+") as file:
                json.dump(default, file, indent=4)
            logger.warning(f"Created default configuration at {self.config_path}")


manager = Manager()
