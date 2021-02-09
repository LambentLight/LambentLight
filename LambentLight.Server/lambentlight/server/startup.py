import argparse
import contextlib
import json
import logging
import os
from platform import system

import aiofiles
from aiohttp import web

from lambentlight.server import __version__ as version
from .config import default_server
from .exceptions import LambentLightServerException
from .manager import Manager
from .web import app

logger = logging.getLogger("lambentlight")


def get_arguments():
    """
    Gets the parsed launch arguments.
    """
    # Create the parser
    parser = argparse.ArgumentParser(description="Daemon for managing your CFX Servers.",
                                     epilog="Check https://justalemon.ml/LambentLight for more info.",
                                     add_help=True, formatter_class=argparse.ArgumentDefaultsHelpFormatter)
    # Add the arguments
    work_dir = "C:\\ProgramData\\LambentLight" if system() == "Windows" else "/var/lib/lambentlight"
    parser.add_argument("--work-dir", dest="work_dir", default=work_dir,
                        help="folder used to store the server data")
    parser.add_argument("--init", dest="init", action="store_true",
                        help="initializes the configuration file")
    parser.add_argument("--host", dest="host", default="127.0.0.1",
                        help="the host or IP address to bind")
    parser.add_argument("--port", dest="port", default=8019,
                        help="the port of the web server")
    # And return them parsed
    return parser.parse_args()


def configure_loggers():
    """
    Configures the loggers.
    """
    # Get the loggers required in a list
    loggers = [
        logging.getLogger("lambentlight"),
        logging.getLogger("aiohttp.access"),
    ]
    # Set the format of the logger
    formatter = logging.Formatter("[%(asctime)s - %(levelname)s] %(message)s")
    stream = logging.StreamHandler()
    stream.setFormatter(formatter)
    # And add the handlers to the loggers
    for new_logger in loggers:
        new_logger.setLevel(logging.INFO)
        new_logger.addHandler(stream)


async def initialize_config(directory):
    """
    Initializes the LambentLight configuration file.
    """
    # Make the path of the configuration file
    path = os.path.join(directory, "config.json")

    # If the file exists, warn the user
    if os.path.isfile(path):
        logger.warning(f"Configuration file '{path}' exists, the file will be overridden")

    # Create the data directory if it does not exists
    with contextlib.suppress(FileExistsError):
        await aiofiles.os.mkdir(directory)

    # Then, go ahead and write the default configuration
    async with aiofiles.open(path, "w") as file:
        text = json.dumps(default_server, indent=4) + "\n"
        await file.write(text)
    logger.info(f"Configuration was written to '{path}'")
    return 0


async def create_manager(directory, host, port):
    """
    Creates a LambentLight server manager in the specified directory.
    """
    logger.info(f"Starting LambentLight {version}")

    # Try to initialize the server
    try:
        manager = Manager(directory)
        await manager.update_builds()
        await manager.update_folders()
        await manager.autostart_servers()
    # If we failed, raise an exception and return
    except LambentLightServerException as e:
        logger.error(str(e))
        logger.error("Manager Initialization Failed")
        return 4

    # Then, try to start the web server
    try:
        app["manager"] = manager
        runner = web.AppRunner(app, access_log_format="HTTP Request from %a: %r (%s) [%{User-Agent}i]")
        await runner.setup()
        site = web.TCPSite(runner, host, port)
        logger.info(f"Starting Web Server at {host}:{port}")
        await site.start()
    # If we failed, raise an exception and return
    except OSError as e:
        logger.error(f"Web server could not be started: Code {e.errno}")
        return 5

    # Initialization is done!
    # Return the manager to be used somewhere else
    return manager
