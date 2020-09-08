import os

import lambentlight.client as client


user_agent = f"LambentLight Client/{client.__version__} (+https://justalemon.ml/LambentLight)"
token = os.environ.get("LAMBENTLIGHT_TOKEN", "")
headers = {
    "Authorization": f"Bearer {token}",
    "User-Agent": user_agent
} if token else {
    "User-Agent": user_agent
}
host = os.environ.get("LAMBENTLIGHT_HOST", "http://127.0.0.1:8019")
