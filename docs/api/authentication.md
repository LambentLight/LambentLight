# Authenticating your calls

!!! tip
    Although is not recommended, you can disable the authentication by leaving the Token field empty and saving it.

To use the endpoints, you need to authenticate your calls via the `Authorization` header, like this:

```
Authorization: Bearer CZJkbuYKkml4i42xd9kb5IhmGMPwYNwNxjZmU4ZCNdU=
```

You can get your token by clicking "Make token visible" and copying from the text box:

![The API Settings](../images/api/token.png)

!!! info
    The header `Authorization` is case insensitive, see [Are HTTP headers case-sensitive?](https://stackoverflow.com/q/5258977) on Stack Overflow for more information.
