# Getting started

## Installation

Before installing LambentLight, make sure that you have [.NET Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452) installed.

The process is easy, just download the compressed file from [GitHub][releases-url] or [5mods][5mods-url], extract it, and run `LambentLight.exe`.

!!! warning
    Don't run `LambentLight.exe` from the compressed file, all of your data will be lost after restarting Windows.

## Usage

To start, you need to add a CFX License. Press <img src="../../images/icons/SettingsApplications.png" width="3%"> to open the settings and click `Generate` on `CFX License`. A web page will open on your default browser.

You need to log in to generate a CFX License, so press `sign in` and follow the steps to use your FiveM/CFX Forum Account. After logging in, press `New` at the top of the page to create a new license. You need to fill all of the fields with the following information:

* `Label`: Here you can place any name that you want to identify this license
* `Server IP address`: Write `127.0.0.1` (you can use any IP, but this one will always work)
* `Server type`: Select either:
   * `Home hosted` (if you are launching the server from your own home and your own computer)
   * `Dedicated server` (if you have a computer or server dedicated for the FiveM/RedM Server)
   * `VPS` (if you are using Amazon EC2, DigitalOcean or others)

After filling the fields, click `Generate`. The license will be visible on the list, copy it and go back to the LambentLight settings window. Press `Make License Visible` to enable the text field, paste it and press save `Save`.

The last step is creating a Data Folder. Press <img src="../../images/icons/Add.png" width="3%"> to open the Data Folder Creator, enter a name for your new folder and press `Create`. Then, wait until the 

Once you have completed all of the previous steps, press <img src="../../images/icons/Play.png" width="3%"> to launch your FiveM or RedM server. If you want to safely stop the server, press <img src="../../images/icons/Stop.png" width="3%">.

[releases-url]: https://github.com/LambentLight/LambentLight/releases
[5mods-url]: https://www.gta5-mods.com/tools/servermanager
