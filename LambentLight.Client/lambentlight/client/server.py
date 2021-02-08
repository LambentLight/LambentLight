import humanize
import lambentlight.client as client


async def start_server(name: str, build: str):
    """
    Starts a CFX Server.
    """
    # Create a place to store the request data
    data = {
        "folder": name
    }

    # Set the most up to date folder (if required)
    if build.lower() == "latest":
        data["use_latest"] = True
    else:
        data["build"] = build

    # And make the request
    info = await client.put("/servers", data)
    info["mem"] = humanize.naturalsize(info["mem"])
    info["build"] = info["build"]["name"]
    client.print_as_table(info, capitalize=True)


async def get_server(name: str):
    """
    Prints the information of the server.
    """
    info = await client.get(f"/servers/{name}")
    info["mem"] = humanize.naturalsize(info["mem"])
    info["build"] = info["build"]["name"]
    client.print_as_table(info, capitalize=True)
