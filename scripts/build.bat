@echo off
pyi-makespec --name lambentlight --onefile scripts\build_client.py --console --icon icon.ico --win-no-prefer-redirects
pyi-makespec --name lambentlightd --onefile scripts\build_server.py --console --icon icon.ico --win-no-prefer-redirects
pyinstaller --clean lambentlight.spec
pyinstaller --clean lambentlightd.spec
