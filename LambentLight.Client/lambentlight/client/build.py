import lambentlight.client as client


async def update_builds():
    """
    Updates the list of builds.
    """
    # Call the endpoint, that's it
    await client.post("/builds")


async def show_builds():
    """
    Shows the full list of builds.
    """
    # Get the list of builds
    builds = await client.get("/builds")
    # If none were found, show a message and return
    if not builds:
        print("There are no builds.")
        return
    # Otherwise, print them in the console
    values = [
        [
            "Name",
            "Ready"
        ]
    ]
    for build in builds:
        values.append([build["name"], "Yes" if build["is_ready"] else "No"])
    client.print_list(*values)


async def show_build(build):
    """
    Shows the information of a Build.
    """
    json = await client.get(f"/builds/{build}")
    print("Name", json["name"], sep="\t\t\t")
    print("Download URL", json["url"] if json["url"] else "Not Present", sep="\t\t")
    print("Ready to be Used", json["is_ready"], sep="\t")


async def delete_build(build):
    """
    Deletes/Uninstalls the specified Build.
    """
    await client.delete(f"/builds/{build}")
