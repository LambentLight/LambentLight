from aiohttp import web


def requires_build(func):
    """
    Decorator that makes a route get a Build.
    """
    async def decorator(self):
        for build in self.request.app["manager"].builds:
            if build.name == self.request.match_info["name"]:
                return await func(self, build)
        return web.json_response({"message": "No Builds Running were found with the specified Name"},
                                 status=404)
    return decorator


def requires_folder(func):
    """
    Decorator that makes a route get a Data Folder.
    """
    async def decorator(self):
        for folder in self.request.app["manager"].folders:
            if folder.name == self.request.match_info["name"]:
                return await func(self, folder)
        return web.json_response({"message": "No Data Folders Running were found with the specified Name"},
                                 status=404)
    return decorator


def requires_server(func):
    """
    Decorator that makes a route get a Server Running.
    """
    async def decorator(self):
        for folder in self.request.app["manager"].folders:
            if folder.name == self.request.match_info["name"] and folder.is_running:
                return await func(self, folder)
        return web.json_response({"message": "No Servers Running were found with the specified Name"},
                                 status=404)
    return decorator
