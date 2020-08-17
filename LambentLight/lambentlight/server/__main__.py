import asyncio
import logging

from aiohttp import web

from .arguments import arguments
from .checks import is_valid
from .manager import manager
from .web import app
from lambentlight import __version__


async def start():
    """
    Starts the LambentLight Server.
    """
    # Configure the logging levels in all of the loggers
    logger = logging.getLogger("lambentlight")
    logger.setLevel(logging.INFO)
    formatter = logging.Formatter("[%(asctime)s - %(levelname)s] %(message)s")
    stream = logging.StreamHandler()
    stream.setFormatter(formatter)
    logger.addHandler(stream)
    # Notify that we are stating the server
    logger.info(f"Starting LambentLight {__version__}")
    # If we are not running a valid operating system, return
    if not is_valid:
        logger.critical("Operating system is not Compatible (needs to be Windows or Ubuntu)")
        return
    # Perform the manager initialization
    if not await manager.initialize():
        logger.error("Manager Initialization Failed")
        return
    # And start the web server
    runner = web.AppRunner(app)
    await runner.setup()
    site = web.TCPSite(runner, arguments.host, arguments.web_port)
    logger.info(f"Starting Web Server at {arguments.host}:{arguments.web_port}")
    try:
        await site.start()
    except OSError as e:
        logger.error(f"Web server could not be started: Code {e.errno}")
    # Then, just block the server
    while True:
        await asyncio.sleep(0)


def main():
    """
    Initializes the LambentLight Server Loop.
    """
    if not hasattr(arguments, "help"):
        loop = asyncio.get_event_loop()
        try:
            loop.run_until_complete(start())
        except KeyboardInterrupt:
            loop.stop()
            asyncio.get_event_loop().run_until_complete(manager.close())


if __name__ == "__main__":
    main()
