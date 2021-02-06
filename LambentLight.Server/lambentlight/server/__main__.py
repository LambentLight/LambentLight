import asyncio
import contextlib
import json
import logging
import os

import aiofiles
from aiohttp import web

import lambentlight.server as server


async def start():
    """
    Starts the LambentLight Server.
    """
    # Configure the logging levels in all of the loggers
    loggers = [
        logging.getLogger("lambentlight"),
        logging.getLogger("aiohttp.access"),
    ]
    formatter = logging.Formatter("[%(asctime)s - %(levelname)s] %(message)s")
    stream = logging.StreamHandler()
    stream.setFormatter(formatter)
    for logger in loggers:
        logger.setLevel(logging.INFO)
        logger.addHandler(stream)

    # If we only need to initialize the config, do it and exit
    if server.arguments.init:
        config = os.path.join(server.arguments.work_dir, "config.json")
        if os.path.isfile(config):
            loggers[0].warning(f"Configuration file '{config}' exists")
        with contextlib.suppress(FileNotFoundError):
            await aiofiles.os.mkdir(server.arguments.work_dir)
        async with aiofiles.open(config, "w") as file:
            text = json.dumps(server.default_config, indent=4) + "\n"
            await file.write(text)
        loggers[0].info(f"Configuration was written to '{config}'")
        return

    # Notify that we are stating the server
    loggers[0].info(f"Starting LambentLight {server.__version__}")
    # If we are not running a valid operating system, return
    if not server.is_valid:
        loggers[0].critical("Operating system is not Compatible (needs to be Windows or Ubuntu)")
        return
    # Perform the manager initialization
    if not await server.manager.initialize():
        loggers[0].error("Manager Initialization Failed")
        return
    # And start the web server
    runner = web.AppRunner(server.app, access_log_format="HTTP Request from %a: %r (%s) [%{User-Agent}i]")
    await runner.setup()
    site = web.TCPSite(runner, server.arguments.host, server.arguments.web_port)
    loggers[0].info(f"Starting Web Server at {server.arguments.host}:{server.arguments.web_port}")
    try:
        await site.start()
    except OSError as e:
        loggers[0].error(f"Web server could not be started: Code {e.errno}")
    # Then, just block the server
    while True:
        await asyncio.sleep(0)
        await server.manager.process()


def main():
    """
    Initializes the LambentLight Server Loop.
    """
    if not hasattr(server.arguments, "help"):
        if server.is_windows:
            asyncio.set_event_loop_policy(asyncio.WindowsProactorEventLoopPolicy())
        loop = asyncio.get_event_loop()
        try:
            loop.run_until_complete(start())
        except KeyboardInterrupt:
            loop.stop()
            asyncio.get_event_loop().run_until_complete(server.manager.close())


if __name__ == "__main__":
    main()
