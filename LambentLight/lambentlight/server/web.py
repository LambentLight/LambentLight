from aiohttp import web

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


app.add_routes(routes)
