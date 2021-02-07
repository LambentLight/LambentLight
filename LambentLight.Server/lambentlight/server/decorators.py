from aiohttp import web

from lambentlight import server


def requires_build(func):
    """
    Decorator that makes a route get a Build.
    """
    async def decorator(self):
        matches = [x for x in server.manager.builds if x.name == self.request.match_info["name"]]
        if not matches:
            return web.json_response({"message": "No Builds were found with the specified Name."},
                                     status=404)
        return await func(self, matches[0])
    return decorator


def requires_folder(func):
    """
    Decorator that makes a route get a Data Folder.
    """
    async def decorator(self):
        matches = [x for x in server.manager.folders if x.name == self.request.match_info["name"]]
        if not matches:
            return web.json_response({"message": "No Data Folders were found with the specified Name."},
                                     status=404)
        return await func(self, matches[0])
    return decorator


def requires_server(func):
    """
    Decorator that makes a route get a Server Running.
    """
    async def decorator(self):
        matches = [x for x in server.manager.folders if x.name == self.request.match_info["name"] and x.is_running]
        if not matches:
            return web.json_response({"message": "No Servers Running were found with the specified Name"},
                                     status=404)
        return await func(self, matches[0])
    return decorator
