import asyncio

from aiohttp import web

from .arguments import arguments
from .web import app


async def main():
    # And start the web server
    runner = web.AppRunner(app)
    await runner.setup()
    site = web.TCPSite(runner, arguments.host, arguments.web_port)
    await site.start()


if __name__ == "__main__":
    if not hasattr(arguments, "help"):
        loop = asyncio.get_event_loop()
        loop.create_task(main())
        try:
            loop.run_forever()
        except KeyboardInterrupt:
            loop.stop()
