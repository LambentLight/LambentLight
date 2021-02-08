import sys
from typing import Union

import aiohttp

import lambentlight.client as client


async def handle_response(resp):
    """
    Handles the response returned by the HTTP Request.
    """
    # If the code is 400 or 500,
    if resp.status >= 400:
        print(f"Request failed with code {resp.status}")
        sys.exit(2)
    # If we got a 204 no content, return None
    elif resp.status == 204:
        return None
    # For anything else, try to parse the response as JSON
    else:
        return await resp.json()


async def request(method: str, route: str, data: Union[dict, list] = None):
    """
    Makes a request with the specified method.
    """
    async with aiohttp.ClientSession(headers=client.headers) as session:
        url = client.host + route
        try:
            async with session.request(method, url, json=data) as resp:
                return await handle_response(resp)
        except aiohttp.ClientConnectionError as e:
            print(str(e))
            sys.exit(3)


async def get(route: str):
    """
    Makes a GET Request.
    """
    return await request("GET", route)


async def post(route: str, data: dict = None):
    """
    Makes a POST Request.
    """
    return await request("POST", route, data)


async def put(route: str, data: dict = None):
    """
    Makes a PUT Request.
    """
    return await request("PUT", route, data)


async def delete(route: str):
    """
    Makes a DELETE Request.
    """
    return await request("DELETE", route)
