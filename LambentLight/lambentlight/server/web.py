import json

from aiohttp import web

from .manager import manager
from lambentlight import __version__


app = web.Application()
routes = web.RouteTableDef()


@routes.get("/")
async def info(request):
    """
    Shows the LambentLight information.
    """
    pinfo = {
        "version": __version__
    }
    headers = {
        "Cache-Control": f"max-age={60 * 60}"  # 1 hour
    }
    return web.json_response(pinfo, headers=headers)

@routes.get("/builds")
async def builds(request):
    """
    Shows a list of builds.
    """
    # Create the list of builds based on the manager builds
    blist = []
    for build in manager.builds:
        binfo = {
            "name": build.name,
            "ready": build.is_ready
        }
        blist.append(binfo)
    # And return it as JSON
    headers = {
        "Cache-Control": f"max-age={60 * 60}"  # 1 hour
    }
    return web.json_response(blist, headers=headers)


@routes.post("/builds/download")
async def download_build(request: web.Request):
    """
    Downloads a specific build.
    """
    # Try to get the request as JSON
    try:
        data = await request.json()
    except json.JSONDecodeError:
        return web.json_response({"message": "Body is not JSON or is malformed."}, status=400)
    # If the request does not has an ID, return a 400
    if "name" not in data:
        return web.json_response({"message": "No Build name was specified."}, status=400)
    # Try to get the builds that match the ID
    matches = [x for x in manager.builds if x.name == data["name"]]
    # If no matches were found, return a 404
    if not matches:
        return web.json_response({"message": "No Builds were found with that name"}, status=404)
    # Get the build that we plan to manage
    build = matches[0]
    # If is already ready to be used and is not forced, return
    if build.is_ready and not data.get("force", False):
        return web.json_response({"message": "Build is already Downloaded and Ready."}, status=409)
    # Otherwise, start the download and notify if it was a success
    else:
        success = await build.download(manager.session)
        if success:
            return web.json_response({"message": "Build was downloaded"})
        else:
            return web.json_response({"messages": "Error when downloading the build."}, status=500)


app.add_routes(routes)
