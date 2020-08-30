import math

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
    # Calculate the tabs required for the big names
    biggest = 0
    for key in servers:
        newlen = len(key)
        if newlen > biggest:
            biggest = newlen
    maxsize = math.floor((biggest / 8) + 1)
    # And print the information of the servers
    for key, item in servers.items():
        # Start with the title
        print(key, end=" ")
        # The print the number of tabs required after the name
        tabcount = maxsize - math.floor(len(key) / 8)
        while tabcount:
            print("\t", end="")
            tabcount -= 1
        # Then, go for the CPU Usage and finish with the readable Memory
        print(item["cpu"], end="\t")
        print(humanize.naturalsize(item["mem"]))
