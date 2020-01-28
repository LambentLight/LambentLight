# Endpoints for Data Folders

## Get Data Folders

**GET** /datafolders

### Description

Returns a list of [`Data Folder`](objects.md#data-folder) objects.

## Refresh Data Folders

**POST** /datafolders

### Description

Refreshes the list of Data Folders in the manager and the UI. Returns a `204 No Content` response on success.

## Get Installed Resources

**GET** /datafolders/{folder.name}/resources

### Description

Returns a list of [`Installed Resource`](objects.md#installed-resource) objects.
