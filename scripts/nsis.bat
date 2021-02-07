@echo off
if not exist "bin\Installer" mkdir bin\Installer
makensis nsis.nsi
