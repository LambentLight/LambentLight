# LambentLight [![5mods][5mods-img]][5mods-url] [![AppVeyor][appveyor-img]][appveyor-url] [![CodeFactor][codefactor-img]][codefactor-url] [![Discord][discord-img]][discord-url]

LambentLight is an application for managing dedicated FiveM servers. It helps you with a bunch of tedious tasks:

* Keeping your server safe by using the latest available build, no more manual updating of builds
* Integrated resource installer, so you no longer need to browse the FiveM forums for installing every dependency manually
* Ability to change your server settings from inside of the application
* The server is restarted automatically if it crashes, no need to worry for a 24/7 operation
* Automatic scheduled restarts, so you can update builds and resources at specific times of the day
* Is 100% Free and Open Source under the MIT License

<div align="center">
    <img src="preview.png"/>
</div>

# Installation

## Windows

1. Download the compressed file from [GitHub Releases][releases-url] or [5mods][5mods-url]
2. Extract the files inside of the 7zip and run `LambentLight.exe`

## Linux

1. Add the [Mono Repositories](https://www.mono-project.com/download/stable/#download-lin-ubuntu) and update your apt cache
2. Install the Mono Runtime and Visual Basic libraries (`sudo apt install mono-runtime mono-vbnc`)
3. Download the compressed file from [GitHub Releases][releases-url]
4. Extract the files inside of the 7zip and run `mono LambentLight.exe`

# Usage

1. First, go to `Application Settings` and add a FiveM License
   1. Click `Generate` to open the FiveM License page on your browser
   2. Follow the steps on the FiveM license page
   3. Once you have the License, go back to the program and click `Make License Visible`
   4. Paste the license on the text box and click `Save`
2. On the top bar, click `Create Data Folder` and follow the instructions
3. Click `Start Server` to launch your own FiveM server

[5mods-img]: https://img.shields.io/badge/5mods-download-20BA4E.svg
[5mods-url]: https://www.gta5-mods.com/tools/servermanager
[appveyor-img]: https://img.shields.io/appveyor/ci/justalemon/lambentlight.svg?label=appveyor
[appveyor-url]: https://ci.appveyor.com/project/justalemon/lambentlight
[codefactor-img]: https://www.codefactor.io/repository/github/lambentlight/lambentlight/badge
[codefactor-url]: https://discord.gg/Cf6sspj
[discord-img]: https://img.shields.io/badge/discord-join-7289DA.svg
[discord-url]: https://www.codefactor.io/repository/github/justalemon/lambentlight
[releases-url]: https://github.com/LambentLight/LambentLight/releases
