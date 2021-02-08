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
    # LIST SERVERS
    server = subparsers.add_parser("servers",
                                   help="lists the Servers currently running")   # LIST BUILDS
    builds = subparsers.add_parser("builds",
                                   help="Lists the Builds known by LambentLight")
    builds.add_argument("-U", "--update", action="store_true",
                        help="Updates the list of Builds before requesting them.")
    # MANAGE BUILDS
    build = subparsers.add_parser("build",
                                  help="Manages specific Builds")
    build.add_argument("build")
    build_tasks = build.add_mutually_exclusive_group()
    build_tasks.add_argument("-d", "--download", action="store_true",
                             help="downloads the build")
    build_tasks.add_argument("-r", "--remove", action="store_true",
                             help="removes or uninstalls the build")
    build.add_argument("--force", action="store_true",
                       help="forces the operation to be completed")
    # And return them parsed
    return parser.parse_args()


arguments = parse_arguments()
