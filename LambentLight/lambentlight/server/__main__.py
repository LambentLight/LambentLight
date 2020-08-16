import asyncio
import logging

from aiohttp import web

from .arguments import arguments
from .checks import is_valid
from .web import app
from lambentlight import __version__


async def main():
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
    # And start the web server
    runner = web.AppRunner(app)
    await runner.setup()
    site = web.TCPSite(runner, arguments.host, arguments.web_port)
    logger.info(f"Starting Web Server at {arguments.host}:{arguments.web_port}")
    await site.start()


if __name__ == "__main__":
    if not hasattr(arguments, "help"):
        loop = asyncio.get_event_loop()
        loop.create_task(main())
        try:
            loop.run_forever()
        except KeyboardInterrupt:
            loop.stop()
