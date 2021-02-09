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
    # BUILD
    if args.command == "build":
        if args.action == "delete":
            await client.delete_build(args.build)
        elif args.action == "download":
            await client.download_build(args.build, args.force)
        elif args.action == "info":
            await client.show_build(args.build)
    # BUILDS
    elif args.command == "builds":
        if args.refresh:
            await client.update_builds()
        await client.show_builds(args.ready_only)
    # FOLDER
    elif args.command == "folder":
        if args.action == "create":
            await client.create_folder(args.folder, args.no_resources)
        elif args.action == "info":
            await client.get_folder(args.folder)
        elif args.action == "resources":
            await client.get_resources(args.folder)
        elif args.action == "delete":
            await client.delete_folder(args.folder)
    # FOLDERS
    elif args.command == "folders":
        await client.show_folders()
    # SERVER
    elif args.command == "server":
        if args.action == "start":
            await client.start_server(args.server, args.build)
        elif args.action == "info":
            await client.get_server(args.server)
        elif args.action == "stop":
            await client.stop_server(args.server)
    # SERVERS
    elif args.command == "servers":
        await client.print_servers()
    # INFO
    else:
        await client.show_info()


def main():
    asyncio.run(run())


if __name__ == "__main__":
    main()
