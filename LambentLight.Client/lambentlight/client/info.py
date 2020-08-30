import lambentlight.client as client


async def show_info():
    """
    Shows the basic information of the LambentLight instance.
    """
    # Request the basic info and print it
    info = await client.get("/")
    print("Program:", "\t", info["prog"], sep=" ")
    print("Version:", "\t", info["version"], sep=" ")
