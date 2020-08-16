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


app.add_routes(routes)
