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

    build = subparsers.add_parser("build", aliases=["b"],
                                  help="Manages specific Builds")
    build.add_argument("build")
    build_tasks = build.add_mutually_exclusive_group()
    build_tasks.add_argument("-d", "--download", action="store_true",
                             help="downloads the build")
    build_tasks.add_argument("-r", "--remove", action="store_true",
                             help="removes or uninstalls the build")
    build.add_argument("--force", action="store_true",
                       help="forces the operation to be completed")
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
    elif args.command == "build":
        if args.download:
            pass
        elif args.remove:
            await client.delete_build(args.build)
        else:
            await client.show_build(args.build)


def main():
    asyncio.run(run())


if __name__ == "__main__":
    main()
