import lambentlight.client as client


async def show_info():
    """
    Shows the basic information of the LambentLight instance.
    """
    # Request the basic info and print it
    info = await client.get("/")
    print("{0} v{1} running on {2}".format(info["prog"], info["version"], client.host))
