import os

import lambentlight.client as client


user_agent = f"LambentLight/{client.__version__} (+https://justalemon.ml/LambentLight)"
token = os.environ.get("LAMBENTLIGHT_TOKEN", "")
headers = {
    "Authorization": f"Bearer {token}",
    "User-Agent": user_agent
} if token else {
    "User-Agent": user_agent
}
ssl = os.environ.get("LAMBENTLIGHT_SSL", "1") == "1"
address = os.environ.get("LAMBENTLIGHT_ADDRESS", "127.0.0.1")
port = os.environ.get("LAMBENTLIGHT_PORT", "8019")
protocol = "https" if ssl else "http"
url = f"{protocol}://{address}:{port}"
