# LambentLight<br>[![AppVeyor][appveyor-img]][appveyor-url] [![Patreon][patreon-img]][patreon-url] [![PayPal][paypal-img]][paypal-url] [![Discord][discord-img]][discord-url]

LambentLight is a Server Manager for the FiveM and RedM multiplayer modifications for GTA V and RDR2 Respectively.

It allows you to Start, Restart and Stop your server process, create new Server Folders, Download, Install, Reinstall and Delete Resources and much more!

## Download

* [GitHub](https://github.com/LambentLight/LambentLight/releases)
* [5mods](https://www.gta5-mods.com/tools/servermanager)
* [AppVeyor](https://ci.appveyor.com/project/justalemon/lambentlight) (experimental)

## Installation

> If you are using an old version of LambentLight, visit https://lambentlight.github.io/LambentLight/getting-started/

The current version of LambentLight is being rewritten in Python and is not yet available on pypi. You can go ahead and install it via git and pip:

```sh
git clone https://github.com/LambentLight/LambentLight.git
python -m pip install -e ./LambentLight/LambentLight.Server # For the Server
python -m pip install -e ./LambentLight/LambentLight.Client # For the Client
```

## Usage

> If you are using an old version of LambentLight, visit https://lambentlight.github.io/LambentLight/getting-started/

After installing LambentLight, you can start the server by running

```sh
python -m lambentlight.server
```

[appveyor-img]: https://img.shields.io/appveyor/build/justalemon/lambentlight?label=appveyor
[appveyor-url]: https://ci.appveyor.com/project/justalemon/lambentlight
[patreon-img]: https://img.shields.io/badge/support-patreon-FF424D.svg
[patreon-url]: https://www.patreon.com/lemonchan
[paypal-img]: https://img.shields.io/badge/support-paypal-0079C1.svg
[paypal-url]: https://paypal.me/justalemon
[discord-img]: https://img.shields.io/badge/discord-join-7289DA.svg
[discord-url]: https://discord.gg/Cf6sspj
