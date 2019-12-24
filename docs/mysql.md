# MySQL Database

LambentLight allows you to automatically create the databases and tables that the resources need while they are being installed. It works with famous gamemodes like ESX and vRP!

!!! warning
    You need to manually install the MySQL Driver(s) that your resource needs before the main one is installed (for example, `esplugin_mysql` before `essentialmode` and `ESX`).

First, you need to open the settings by pressing <img src="../../images/icons/SettingsApplications.png" width="3%">. On `Connection URL` press `Make URL Visible` and write/paste the MySQL Connection string for the database. A MySQL Connection string looks like this:

```
Server=127.0.0.1;Uid=lemon;Pwd=isme;
```

Where:

* `127.0.0.1` is the `Server` IP
* `lemon` is the User ID or `Uid`
* `isme` is the Password or `Pwd`

!!! info
    The MySQL User needs to have access to create, modify and delete all of the databases in the server.

!!! danger
    Don't use the `Database` parameter on the connection string, this will prevent LambentLight from managing the different databases that scripts require.
