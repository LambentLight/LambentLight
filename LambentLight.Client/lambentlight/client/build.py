import lambentlight.client as client


async def show_build(build):
    """
    Shows the information of a Build.
    """
    json = await client.get(f"/builds/{build}")
    print("Name", json["name"], sep="\t\t\t")
    print("Download URL", json["url"] if json["url"] else "Not Present", sep="\t\t")
    print("Ready to be Used", json["is_ready"], sep="\t")


async def download_build(build: str, force: bool):
    """
    Downloads the Build.
    """
    # Make a GET request to make sure that the build is present
    await client.get(f"/builds/{build}")
    # If is, then go ahead and download it
    print(f"Starting download of {build}")
    await client.post(f"/builds/{build}", {"force": force})


async def delete_build(build):
    """
    Deletes/Uninstalls the specified Build.
    """
    await client.delete(f"/builds/{build}")
