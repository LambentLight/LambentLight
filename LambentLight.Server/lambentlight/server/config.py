import secrets
import string

default_server = {
    "token": "".join(secrets.choice(string.ascii_letters + string.digits) for _ in range(32)),
    "builds": [
        "https://raw.githubusercontent.com/LambentLight/Builds/master/builds.json"
    ],
    "no_auth_local": True,
    "allowed_ips": [
        "127.0.0.1"
    ]
}
default_folder = {
    "auto_start": False,
    "auto_start_build": "",
    "token_cfx": "",
    "token_steam": "",
    "game": "gtav",
    "exec": ["server.cfg"]
}
