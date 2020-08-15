import asyncio

from aiohttp import web

from .arguments import parse_arguments
from .web import app


async def main():
    # Parse the arguments from the Command Line
    arguments = parse_arguments()
    # And start the web server
    runner = web.AppRunner(app)
    await runner.setup()
    site = web.TCPSite(runner, arguments.host, arguments.web_port)
    await site.start()


if __name__ == "__main__":
    loop = asyncio.get_event_loop()
    loop.create_task(main())
    loop.run_forever()
