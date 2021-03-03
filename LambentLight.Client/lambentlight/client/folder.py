import lambentlight.client as client


async def create_folder(name: str, no_resources: bool):
    """
    Creates the specified Data Folder.
    """
    info = await client.put("/folders", {"name": name, "skip_resources": no_resources})
    client.print_as_table(info, capitalize=True)


async def get_folder(name: str):
    """
    Gets the information of a specific folder.
    """
    info = await client.get(f"/folders/{name}")
    client.print_as_table(info, capitalize=True)


async def get_resources(name: str):
    """
    Gets the resources present on a Data Folder.
    """
    info = await client.get(f"/folders/{name}/resources")
    client.print_with_header(["Name", "Path"], *[[x["name"], x["path"]] for x in info])


async def delete_folder(name: str):
    """
    Deletes a specific data folder.
    """
    await client.delete(f"/folders/{name}")
    print(f"Folder {name} was deleted")
