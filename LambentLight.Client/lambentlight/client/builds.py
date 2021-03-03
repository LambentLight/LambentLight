import lambentlight.client as client


async def show_builds(ready_only: bool):
    """
    Shows the full list of builds.
    """
    # Get the list of builds
    builds = await client.get("/builds")
    # And print those needed
    values = []
    for build in builds:
        if ready_only and not build["is_ready"]:
            continue
        values.append([build["name"], "Yes" if build["is_ready"] else "No"])
    client.print_with_header(["Name", "Ready"], *values)


async def update_builds():
    """
    Updates the list of builds.
    """
    # Call the endpoint, that's it
    await client.post("/builds")
