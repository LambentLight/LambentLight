import argparse
import asyncio

import lambentlight.client as client


async def main():
    """
    The main function that parses the arguments.
    """
    # Make the parsers and add the arguments
    parser = argparse.ArgumentParser(description="CLI for managing a LambentLight Server Instance")
    subparsers = parser.add_subparsers(dest="command")
    server = subparsers.add_parser("servers", aliases=["s"],
                                   help="Lists the Servers currently running")
    # Then, parse the arguments
    args = parser.parse_args()

    # If the help argument was used, return
    if hasattr(args, "help"):
        return
    # Otherwise, check the correct command and invoke the respective function
    if args.command == "servers":
        await client.print_servers()


if __name__ == "__main__":
    asyncio.run(main())
