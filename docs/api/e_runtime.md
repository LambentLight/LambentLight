# Endpoints for Controlling the Server Process

## Start Server

**POST** /start

### Description

Starts the server with the specified Build and Data Folder. Returns a `400 Bad Request` if the Build or Data Folder does not exists, `409 Conflict` if the server is already running or `204 No Content` if the server started.

### JSON Parameters

| Name   | Description                               |
| ------ | ----------------------------------------- |
| Build  | The ID of the Build (build.id)            |
| Folder | The Name of the Data Folder (folder.name) |

## Restart Server

**POST** /restart

### Description

Restarts the server. Returns a `409 Conflict` if the server is not running or `204 No Content` if the server was restarted.

## Stop Server

**POST** /stop

### Description

Stops the server. Returns a `409 Conflict` if the server is not running or `204 No Content` if the server was stopped.

## Send Command

**POST** /command

### Description

Sends a command to the server. Returns a `400 Bad Request` if there is no command specified, `409 Conflict` if the server is not running or `202 Accepted` if the command was executed.

We send `202 Accepted` instead of `200 OK` or `204 No Content` because we don't know if the resource that accepts the command will execute the action instantly.

### JSON Parameters

| Name    | Description            |
| ------- | ---------------------- |
| Command | The command to execute |
