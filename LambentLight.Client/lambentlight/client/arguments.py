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
    builds.add_argument("-U", "--update", action="store_true",
                        help="updates the list of builds before showing them")
    builds.add_argument("-R", "--ready-only", action="store_true",
                        help="only list the builds ready to be used")
    # FOLDERS
    subparsers.add_parser("folders",
                          help="lists the Data Folders available")
    # LIST SERVERS
    subparsers.add_parser("servers",
                          help="lists the Servers currently running")
    # And return them parsed
    return parser.parse_args()


arguments = parse_arguments()
