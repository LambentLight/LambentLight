@echo off
pyi-makespec --name lambentlight --onefile scripts\build_client.py --console --icon icon.ico --win-no-prefer-redirects
pyi-makespec --name lambentlightd --onefile scripts\build_server.py --console --icon icon.ico --win-no-prefer-redirects
pyinstaller --distpath bin\Executables --clean lambentlight.spec
pyinstaller --distpath bin\Executables --clean lambentlightd.spec
