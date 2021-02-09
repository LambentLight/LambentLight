import asyncio
import logging

from .arguments import parse_arguments
from .checks import is_valid, is_windows
from .startup import configure_loggers, create_manager, initialize_config

logger = logging.getLogger("lambentlight")


async def start(args=None):
    """
    Starts the LambentLight Server.
    """
    # Parse the arguments if they were not passed
    if not args:
        args = parse_arguments()

    # If we only need to initialize the config, do it and exit
    if args.init:
        await initialize_config(args.work_dir)
    # Otherwise, start the server
    else:
        if not is_valid:
            logger.critical("Operating system is not Compatible (needs to be Windows or Ubuntu)")
            return
        return await create_manager(args.work_dir, args.host, args.web_port)


async def block(manager):
    """
    Blocks the current thread via asyncio.sleep
    """
    while True:
        await asyncio.sleep(0)
        await manager.process()


def main():
    """
    Initializes the LambentLight Server Loop.
    """
    # Get the command line arguments
    args = parse_arguments()

    # First, configure the loggers
    configure_loggers()

    # If the help command was used, do nothing and return
    if hasattr(args, "help"):
        return

    if is_windows:
        asyncio.set_event_loop_policy(asyncio.WindowsProactorEventLoopPolicy())
    loop = asyncio.get_event_loop()
    manager = None
    try:
        manager = loop.run_until_complete(start())
        loop.run_until_complete(block(manager))
    except KeyboardInterrupt:
        loop.stop()
        if manager:
            asyncio.get_event_loop().run_until_complete(manager.close())


if __name__ == "__main__":
    main()
