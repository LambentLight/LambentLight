import argparse
import asyncio

import lambentlight.client as client


async def run():
    """
    The main function that parses the arguments.
    """
    # Make the parsers and add the arguments
    parser = argparse.ArgumentParser(description="CLI for managing a LambentLight Server Instance")
    subparsers = parser.add_subparsers(dest="command")
    server = subparsers.add_parser("servers", aliases=["s"],
                                   help="Lists the Servers currently running")
    info = subparsers.add_parser("info", aliases=["i"],
                                 help="Shows basic information of the current instance")
    builds = subparsers.add_parser("builds", aliases=["bl"],
                                   help="Lists the Builds known by LambentLight")
    builds.add_argument("-U", "--update", action="store_true",
                        help="Updates the list of Builds before requesting them.")
    # Then, parse the arguments
    args = parser.parse_args()

    # If the help argument was used, return
    if hasattr(args, "help"):
        return
    # Otherwise, check the correct command and invoke the respective function
    if args.command == "servers":
        await client.print_servers()
    elif args.command == "info":
        await client.show_info()
    elif args.command == "builds":
        if args.update:
            await client.update_builds()
        await client.show_builds()


def main():
    asyncio.run(run())


if __name__ == "__main__":
    asyncio.run(run())
