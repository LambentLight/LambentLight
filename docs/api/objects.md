# JSON Objects

The following are all of the JSON Objects that the API can return:

## Build

| Name           | Description                                                                 |
| -------------- | --------------------------------------------------------------------------- |
| id             | The identifier of this build (either the folder name or number + SHA1 hash) |
| exe_present    | If the executable is present on the build folder                            |
| folder_present | If there is a folder that has been used for this build                      |
| is_cfx         | If this build is an official CFX Build                                      |

```json
{
    "id": "2024-4097bd1aee1804eaa7d1120ec84bae795c80703d",
    "exe_present": true,
    "folder_present": true,
    "is_cfx": true
}
```

## Data Folder

| Name       | Description                                                              |
| ---------- | ------------------------------------------------------------------------ |
| name       | The name of the Data Folder                                              |
| exists     | If the Data Folder exists (it might have been deleted before refreshing) |
| has_config | If this Data Folder has a configuration file (`server.cfg`)              |

```json
{
    "name": "vRP",
    "exists": true,
    "has_config": false
}
```

## Installed Resource

| Name          | Description                                                                          |
| ------------- | ------------------------------------------------------------------------------------ |
| name          | The name of the folder where the resource is installed                               |
| metadata_type | The type of the metadata file, where 0 is `__resource.lua` and 1 is `fxmanifest.lua` |

```json
{
    "name": "redm-map-one",
    "metadata_type": 1
}
```
