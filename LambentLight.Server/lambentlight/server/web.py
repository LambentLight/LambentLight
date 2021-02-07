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
    # If the client is not whitelisted to connect, send a 403
    if request.remote not in server.manager.config["allowed_ips"]:
        return web.json_response({"message": "Your IP is not Whitelisted."},
                                 status=403)
    # If is localhost/127.0.0.1 and we are allowed to do unauthenticated calls, skip the auth checks
    elif request.remote == "127.0.0.1" and server.manager.config["no_auth_local"]:
        pass
    # If the request does not has an authentication header, return a 401
    elif "Authorization" not in request.headers:
        return web.json_response({"message": "Authentication Token was not specified."},
                                 status=401)
    # If the header does not starts with Bearer
    elif not request.headers["Authorization"].lower().startswith("bearer "):
        return web.json_response({"message": "Authentication Token is not using the right format."},
                                 status=400)
    # If the second part does not matches the token in the config, return
    elif request.headers["Authorization"].split(" ")[1] != server.manager.config["token"]:
        return web.json_response({"message": "Authentication Token is not valid."},
                                 status=401)

    # Otherwise, return a the response of the handler and catch any errors found
    try:
        return await handler(request)
    except Exception as e:
        if isinstance(e, web.HTTPMethodNotAllowed):
            raise
        elif isinstance(e, json.JSONDecodeError):
            return web.json_response({"message": "Body is not JSON or is malformed."},
                                     status=400)
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
                return web.json_response({"message": "Error when downloading the build."}, status=500)

    @server.requires_build
    async def delete(self, build: server.Build):
        """
        Deletes the Build from the server.
        """
        # If the body is not empty, try to parse it as json
        if self.request.body_exists:
            body = await self.request.json()
        else:
            body = {}

        # Check if we need to stop the servers
        stop = body.get("stop", True)
        # Then, try to remove the build with the force parameter
        try:
            await server.manager.remove(build, stop=stop)
        # If there is a server running, return a 409 Conflict
        # This is only raised if stop is True
        except server.ServerRunningException:
            return web.json_response({"message": "There are servers running with this Build."}, status=409)
        # If we got here, every went ok so return a 204 No Content
        return web.Response(status=204)


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

    async def put(self):
        """
        Creates a data folder with the specified name.
        """
        # Try to get the request as JSON
        if self.request.body_exists:
            data = await self.request.json()
        else:
            data = {}

        # If the name does not exists, return a 400
        name = data.get("name", "")
        if not name:
            return web.json_response({"message": "Name was not specified."},
                                     status=400)

        # If there is a folder with the same name, return a 409 Conflict
        if [x for x in server.manager.folders if x.name == name]:
            return web.json_response({"message": "Folder with the same name already exists."},
                                     status=409)
        # Otherwise, tell the manager to create it
        folder = await server.manager.create_folder(name, data.get("from_repo", True))
        return web.json_response(dict(folder))


@routes.view("/folders/{name}")
class FolderView(web.View):
    """
    Route for getting the information of individual Data Folders.
    """
    @server.requires_folder
    async def get(self, folder):
        """
        Prints the information of the Data Folder.
        """
        return web.json_response(dict(folder))


@routes.view("/folders/{name}/resources")
class InstalledResourcesView(web.View):
    """
    Route for getting the resources on Data Folders.
    """
    @server.requires_folder
    async def get(self, folder):
        """
        Gets the list of Resources on the Data Folder.
        """
        if self.request.query.get("simple", "0") != "1":
            return web.json_response([dict(x) for x in folder.resources])
        else:
            return web.json_response([x.name for x in folder.resources])


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
        data = await self.request.json()

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
