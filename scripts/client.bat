@echo off
pyi-makespec --name lambentlight --onefile scripts\client.py --paths .\LambentLight --console --icon icon.ico --win-no-prefer-redirects
pyinstaller --clean lambentlight.spec
