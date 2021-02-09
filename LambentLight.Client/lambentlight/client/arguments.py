import argparse


def parse_arguments():
    """
    Parses the launch arguments.
    """
    # Create the parser
    parser = argparse.ArgumentParser(description="CLI for managing a LambentLight Server Instance")
    # And the subparser
    subparsers = parser.add_subparsers(dest="command")

    # Then, add the subparsers
    # BUILD
    build = subparsers.add_parser("build",
                                  help="shows the information of a specific build")
    buildsub = build.add_subparsers(dest="action")
    buildsub.add_parser("delete",
                        help="deletes the build from the server")
    builddll = buildsub.add_parser("download",
                                   help="downloads the build")
    builddll.add_argument("--force", action="store_true",
                          help="redownloads the build even if is present")
    buildsub.add_parser("info",
                        help="shows the information of the build")
    build.add_argument("build",
                       help="the build to get the information from")
    # BUILDS
    builds = subparsers.add_parser("builds",
                                   help="lists the known CFX Builds")
    builds.add_argument("-R", "--refresh", action="store_true",
                        help="refreshes the list of builds before showing them")
    builds.add_argument("-R", "--ready-only", action="store_true",
                        help="only list the builds ready to be used")
    # FOLDER
    folder = subparsers.add_parser("folder",
                                   help="manages a specific Data Folder")
    foldersub = folder.add_subparsers(dest="action")
    foldernew = foldersub.add_parser("create",
                                     help="creates a new data folder")
    foldernew.add_argument("--no-resources", action="store_true",
                           help="skips the download of stock resources")
    foldersub.add_parser("info",
                         help="shows the information of the Data Folder")
    foldersub.add_parser("resources",
                         help="lists the resources on the Data Folder")
    foldersub.add_parser("delete",
                         help="deletes the Data Folder with all of the resources")
    folder.add_argument("folder",
                        help="the folder to manage or create")
    # FOLDERS
    subparsers.add_parser("folders",
                          help="lists the Data Folders available")
    # SERVER
    server = subparsers.add_parser("server",
                                   help="manages individual servers")
    serversub = server.add_subparsers(dest="action")
    serversta = serversub.add_parser("start",
                                     help="starts a new server")
    serversta.add_argument("-B", "--build", default="latest",
                           help="the build used to start the server")
    serversub.add_parser("info",
                         help="gets the information of the server")
    serversub.add_parser("stop",
                         help="stops a specific CFX Server")
    server.add_argument("server",
                        help="the server to start or manage")
    # SERVERS
    subparsers.add_parser("servers",
                          help="lists the Servers currently running")
    # And return them parsed
    return parser.parse_args()


arguments = parse_arguments()
