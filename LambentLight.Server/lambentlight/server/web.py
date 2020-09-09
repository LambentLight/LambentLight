import json
import logging
import traceback

import aiohttp
from aiohttp import web

import lambentlight.server as server

logger = logging.getLogger("lambentlight")


async def exception_as_response(e: Exception):
    """
    Wraps an exception into a JSON Response.
    """
    data = {
        "message": str(e),
        "traceback": "".join(traceback.TracebackException.from_exception(e).format())
    }
    return web.json_response(data, status=500)


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
    elif request.headers["Authorization"].split(" ")[1] != server.manager.config["token_api"]:
        return web.json_response({"message": "Auth Token is not valid."}, status=401)
    # Otherwise, return a the response of the handler and catch any errors found
    try:
        return await handler(request)
    except Exception as e:
        if isinstance(e, web.HTTPMethodNotAllowed):
            raise
        return await exception_as_response(e)


app = web.Application(middlewares=[auth])
routes = web.RouteTableDef()


@routes.get("/ws")
async def websocket(request: web.Request):
    """
    WebSocket used for the communication of changes.
    """
    # Prepare the WebSocket Response for the Connection
    ws = web.WebSocketResponse()
    await ws.prepare(request)
    logger.info(f"WebSocket connection opened from {request.remote}")
    # Add it to the list of clients
    server.manager.ws_clients.append(ws)
    # And start checking the messages that are coming in
    async for message in ws:
        if message.type == aiohttp.WSMessage.CLOSE:
            break
    # Finally, remove the client from the list
    server.manager.ws_clients.remove(ws)
    logger.info(f"WebSocket connection of {request.remote} has been closed")
    return ws


@routes.get("/")
async def info(request):
    """
    Shows the LambentLight information.
    """
    pinfo = {
        "prog": "LambentLight",
        "version": server.__version__
    }
    headers = {
        "Cache-Control": f"max-age={60 * 60}"  # 1 hour
    }
    return web.json_response(pinfo, headers=headers)


@routes.view("/builds")
class BuildsView(web.View):
    """
    Route for managing the list of Builds.
    """
    async def get(self):
        """
        Shows a list of builds.
        """
        headers = {
            "Cache-Control": f"max-age={2 * 60}"  # 2 minutes
        }
        return web.json_response([dict(x) for x in server.manager.builds], headers=headers)

    async def post(self):
        """
        Triggers an update for the list of Builds.
        """
        await server.manager.update_builds()
        return web.json_response({"count": len(server.manager.builds)})


@routes.view("/builds/{name}")
class BuildView(web.View):
    """
    Route to manage specific builds.
    """
    @server.requires_build
    async def get(self, build):
        """
        Gets the information of a specific build.
        """
        # Just return the build information
        return web.json_response(dict(build))

    @server.requires_build
    async def post(self, build):
        """
        Downloads a specific build.
        """
        # If we are using the build and is not forced, return
        if build.is_ready and self.request.query.get("force", "0") != "1":
            return web.json_response({"message": "Build is already Downloaded and Ready."}, status=409)
        # Otherwise, start the download and notify if it was a success
        else:
            success = await build.download(server.manager.session)
            if success:
                return web.Response(status=204)
            else:
                return web.json_response({"messages": "Error when downloading the build."}, status=500)


@routes.view("/folders")
class FoldersView(web.View):
    """
    Route for managing the list of Data Folders.
    """
    async def get(self):
        """
        Gets the Data Folders known by LambentLight.
        """
        headers = {
            "Cache-Control": f"max-age={2 * 60}"  # 2 minutes
        }
        return web.json_response([dict(x) for x in server.manager.folders], headers=headers)


@routes.view("/servers")
class ServersView(web.View):
    """
    Route for getting the list of Data Folders currently running.
    """
    async def get(self):
        """
        Returns a list of servers.
        """
        headers = {
            "Cache-Control": f"max-age={2 * 60}"  # 2 minutes
        }
        return web.json_response({x.name: x.proc_info for x in server.manager.folders if x.is_running}, headers=headers)


@routes.view("/servers/{name}")
class ServerView(web.View):
    """
    Route used for managing specific servers.
    """
    @server.requires_server
    async def get(self, serv):
        """
        Gets the information of a server.
        """
        return web.json_response(serv.proc_info)

    @server.requires_folder
    async def put(self, folder):
        """
        Starts a new CFX Server for the Data Folder.
        """
        # Then, check if the Data folder is running
        if folder.is_running:
            return web.json_response({"message": "The Server is already running."}, status=409)

        # Try to get the request as JSON and return a 400 if failed
        try:
            data = await self.request.json()
        except json.JSONDecodeError:
            return web.json_response({"message": "Body is not JSON or is malformed."}, status=400)

        # Make sure that the required parameters are present
        if "build" not in data:
            return web.json_response({"message": "Build was not specified."}, status=400)

        # Now, time to find the Build
        found_builds = [x for x in server.manager.builds if x.name == data["build"]]
        if not found_builds:
            return web.json_response({"message": "CFX Build was not found."}, status=404)
        build = found_builds[0]

        # If we have everything, go ahead and start it
        if await folder.start(build):
            return web.json_response(folder.proc_info, status=201)
        else:
            return web.json_response({"message": "Unable to start the server. Check the console."}, status=500)

    @server.requires_server
    async def delete(self, serv):
        """
        Stops a specific server.
        """
        # Just call the stop function and return a 204 No Content
        await serv.stop()
        return web.Response(status=204)


app.add_routes(routes)
