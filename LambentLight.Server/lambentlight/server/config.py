import secrets
import string

default_config = {
    "token": "".join(secrets.choice(string.ascii_letters + string.digits) for _ in range(32)),
    "dl_builds": "https://raw.githubusercontent.com/LambentLight/Builds/master/builds.json",
    "no_auth_local": True,
    "allowed_ips": [
        "127.0.0.1"
    ]
}
