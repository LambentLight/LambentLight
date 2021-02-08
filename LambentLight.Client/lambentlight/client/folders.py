import lambentlight.client as client


async def show_folders():
    """
    Prints the list of data folders.
    """
    # Request the list of data folders
    folders = await client.get("/folders")
    # And tell the function to print them
    client.print_with_header(["Name", "Path"], *[list(x.values()) for x in folders])
