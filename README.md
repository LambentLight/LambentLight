# ServerManager

[![5mods](https://img.shields.io/badge/5mods-download-1B9E42.svg)](https://www.gta5-mods.com/scripts/ggo)
[![AppVeyor](https://img.shields.io/appveyor/ci/justalemon/servermanager.svg?label=appveyor)](https://ci.appveyor.com/project/justalemon/servermanager)
[![CodeFactor](https://www.codefactor.io/repository/github/justalemon/servermanager/badge)](https://www.codefactor.io/repository/github/justalemon/servermanager)
[![Discord](https://img.shields.io/badge/discord-join-7289DA.svg)](https://discord.gg/Cf6sspj)

This is a random project that I have created between the 1st and 4th of January, inspired by another FiveM server manager that was commercial and closed sourced (and ended up being taken down on 5mods, twice).

NOTE: This is not ready for production! I'm not responsable for random crashes and instability.

![Preview](https://raw.githubusercontent.com/justalemon/ServerManager/master/preview.png)

## Prerequisites

* Windows 10 Anniversary Update (build 1607) or higher

## Install

1. Extract the contents of the file with 7zip or WinRar somewhere safe on your PC

## Configuration

### Starting the server

* Select a FXServer Build (if you don't know what to pick, select the first one)
* Add a FiveM Server License (see below for instructions)
* Select a Server Data folder (see below for instructions)
* Click Start Server and you are ready to go

### Adding a FiveM Server License

* On the top bar, click "Generate FiveM License" to open the FiveM page (they are free, just follow the instructions)
* Once you have your license (a 32 digit alphanumeric string like `8X8Kcn7eYnzVNk9d6agRCFnH4Rw3fN35`) go back to ServerManager
* Click Options, paste your License on the text field and click Save

### Creating a Server Data folder

* Click "Create Server Data" on the top
* Insert a name for the Folder
* Click OK and wait for the files to download

## Changelog

### 0.1

* Initial Release

### 0.2

* FIX: The controls are no longer enabled when you try to create a data folder and the server is running
* FIX: Now you are no longer able to start a new server, edit the configuration or change the settings while the server is running (to avoid crashes)
* NEW: When the server crashes, the exit code is shown
* NEW: Added text editor
* NEW: Added option to change server.cfg (the server configuration) directly from the app

### 0.2.1

* FIX: The configuration is now stored correctly

### 0.2.2

* FIX: Now the application is x64 (64 bit) only
* FIX: Instead of showing the recent builds at the bottom, they are now shown at the top

### 0.2.3

* FIX: Things that are not builds no longer show on the build selector

### 0.3

* NEW: Added resource auto installer (just a beta, report any issue found)
* NEW: Updated HtmlAgilityParser from 1.8.11 to 1.8.12
* FIX: Now the builds are shown from recent to older (reverted because of the FiveM download update)

### 0.4

* NEW: Added scheduled restarts
