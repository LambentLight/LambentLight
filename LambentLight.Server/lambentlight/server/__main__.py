import asyncio
import logging
import sys

from .arguments import parse_arguments
from .checks import is_windows
from .startup import configure_loggers, create_manager, initialize_config

logger = logging.getLogger("lambentlight")


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

    # Set the correct loop policy for the operating system
    if is_windows:
        asyncio.set_event_loop_policy(asyncio.WindowsProactorEventLoopPolicy())
    loop = asyncio.get_event_loop()

    # If we need to create the configuration, do so and exit
    if args.init:
        return loop.run_until_complete(initialize_config(args.work_dir))
    # Otherwise, start the server
    else:
        # Create a place to store the manager
        manager = None

        try:
            # Try to initialize the manager
            manager = loop.run_until_complete(create_manager(args.work_dir, args.host, args.port))
            # If is a number, is an exit code so return it
            if manager is int:
                return manager
            # Otherwise, block the thread because everything went OK
            loop.run_until_complete(block(manager))
        except KeyboardInterrupt:
            # Stop the loop
            loop.stop()
            # And if there is a manager, close the connections
            if manager:
                asyncio.get_event_loop().run_until_complete(manager.close())


if __name__ == "__main__":
    sys.exit(main())
