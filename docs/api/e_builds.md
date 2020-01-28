# Endpoints for Builds

## Get Builds

**GET** /build

### Description

Returns a list of [`Build`](objects.md#build) objects.

## Refresh Builds

**POST** /builds

### Description

Refreshes the list of Builds in the manager and the UI. Returns a `204 No Content` response on success.
