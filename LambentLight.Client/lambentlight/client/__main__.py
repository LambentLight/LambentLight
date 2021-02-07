import asyncio

import lambentlight.client as client


async def run():
    """
    The main function that parses the arguments.
    """
    # Get the arguments from the parser
    args = client.arguments

    # If the help argument was used, return
    if hasattr(args, "help"):
        return
    # Otherwise, check the correct command and invoke the respective function
    if args.command == "servers":
        await client.print_servers()
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
    else:
        await client.show_info()


def main():
    asyncio.run(run())


if __name__ == "__main__":
    main()
