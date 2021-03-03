import humanize

import lambentlight.client as client


async def print_servers():
    """
    Prints the servers currently running.
    """
    # Request the list of servers
    servers = await client.get("/servers")
    # Format them to the correct value
    values = []
    for name, info in servers.items():
        values.append([name, info["cpu"], humanize.naturalsize(info["mem"])])
    # And print them to the user
    client.print_with_header(["Name", "CPU%", "Memory Usage"], *values)
