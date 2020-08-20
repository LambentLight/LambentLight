import json

from aiohttp import web

from .manager import manager
from lambentlight import __version__


@web.middleware
async def auth(request: web.Request, handler):
    """
    Checks the token auth.
    """
    # If the request does not has an authentication header, return a 401
    if "Authorization" not in request.headers:
        return web.json_response({"message": "Token not specified."}, status=401)
    # If the header does not starts with Bearer
    elif not request.headers["Authorization"].lower().startswith("bearer "):
        return web.json_response({"message": "Auth Token is not using the right format."}, status=401)
    # If the second part does not matches the token in the config, return
    elif request.headers["Authorization"].split(" ")[1] != manager.config["token_api"]:
        return web.json_response({"message": "Auth Token is not valid."}, status=401)
    # Otherwise, return a the response of the handler
    return await handler(request)


app = web.Application(middlewares=[auth])
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
        "Cache-Control": f"max-age={2 * 60}"  # 2 minutes
    }
    return web.json_response(blist, headers=headers)


@routes.post("/builds")
async def update_builds(request):
    """
    Updates the list of Builds.
    """
    # Just call the method to update builds and return the total number
    await manager.update_builds()
    return web.json_response({"count": len(manager.builds)})


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


@routes.get("/folders")
async def folders(request):
    """
    Gets the Data Folders known by LambentLight.
    """
    # Create the list of data folders based from the manager
    flist = []
    for folder in manager.folders:
        finfo = {
            "name": folder.name,
            "path": folder.path
        }
        flist.append(finfo)
    # And return it as JSON
    headers = {
        "Cache-Control": f"max-age={2 * 60}"  # 2 minutes
    }
    return web.json_response(flist, headers=headers)


app.add_routes(routes)
