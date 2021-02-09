import argparse
from platform import system


work_dir = "C:\\ProgramData\\LambentLight" if system() == "Windows" else "/var/lib/lambentlight"


def parse_arguments():
    """
    Parses the launch arguments.
    """
    # Create the parser
    parser = argparse.ArgumentParser(description="Daemon for managing your CFX Servers.",
                                     epilog="Check https://justalemon.ml/LambentLight for more info.",
                                     add_help=True, formatter_class=argparse.ArgumentDefaultsHelpFormatter)
    # Add the arguments
    parser.add_argument("--work-dir", dest="work_dir", default=work_dir,
                        help="folder used to store the server data")
    parser.add_argument("--init", dest="init", action="store_true",
                        help="initializes the configuration file")
    parser.add_argument("--host", dest="host", default="127.0.0.1",
                        help="the host or IP address to bind")
    parser.add_argument("--port", dest="port", default=8019,
                        help="the port of the web server")
    # And return them parsed
    return parser.parse_args()


arguments = parse_arguments()
