import json
from os.path import join

from .arguments import arguments


class Manager:
    """
    The main manager of LambentLight.
    """
    def __init__(self):
        # Load the configuration of the program
        self.config_path = join(arguments.work_dir, "Config.json")
        with open(self.config_path) as file:
            self.config = json.load(file)


manager = Manager()
