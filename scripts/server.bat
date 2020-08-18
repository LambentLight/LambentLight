@echo off
pyi-makespec --name lambentlightd --onefile scripts\server.py --paths .\LambentLight --console --icon icon.ico --win-no-prefer-redirects
pyinstaller --clean lambentlightd.spec
