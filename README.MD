# .NET archetype


### Configuration to use SQLGateway Service on kubernetes cluster
To use SQLGateway service on kubernetes cluster, you must config the SQLGateway URL on `appsettings.[enviroment].json` file by _*default*_ it's configured to use telepresence.

There are two ways:

- Using *Telepresence*
```json
{
    "SiigoCoreProvider": {
        "SqlGateway": {
          "Url": "http://ms-sqlgateway.siigo-cross:6000"
        }
    }
}
```


- Using *port forward*
```json
{
    "SiigoCoreProvider": {
        "SqlGateway": {
          "Url": "http://localhost:6000"
        }
    }
}
```

This archetype is based on [.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

[.NET Archetype documentation](https://alexandria.siigo.com/books/arquitectura/chapter/arquetipo-net)