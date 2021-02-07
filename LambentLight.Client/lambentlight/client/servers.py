import humanize

import lambentlight.client as client


async def print_servers():
    """
    Prints the servers currently running.
    """
    # Request the list of servers
    servers = await client.get("/servers")
    # If there are none, return
    if not servers:
        print("There are no servers running.")
        return
    # Create the header for the values
    values = [
        [
            "Name",
            "CPU%",
            "Memory Usage"
        ]
    ]
    # And add the server information
    for name, info in servers.items():
        values.append([name, info["cpu"], humanize.naturalsize(info["mem"])])
    # Finally, print the entire thing
    client.print_list(*values)
