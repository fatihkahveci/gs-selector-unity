## Game Server Selector Unity Example

This is an example of how to use the Game Server Selector Unity Example.

## Demo

![image](https://github.com/fatihkahveci/gs-selector-unity/blob/main/gameserver.gif)

## Examples

Simple greater than query example. This query will return all servers that have a capacity greater than 20.

```csharp
var searchRequest = new SearchServerRequest()
                .AddGreaterThanQuery("capacity", 20);
            var servers = _serverListManager.SearchServer(new CancellationToken(), searchRequest);
```

More complex query example. This query will return all servers that have a capacity greater than 20, game_mod is ranked and country is TR.
```csharp
var searchRequest = new SearchServerRequest()
                .AddGreaterThanQuery("capacity", 20)
                .AddEqualQuery("game_mod", "ranked")
                .AddEqualQuery("country", "TR");
            var servers = _serverListManager.SearchServer(new CancellationToken(), searchRequest);
```

## TODOS

- Better UI for example

## Server Repo

[https://github.com/fatihkahveci/game-server-selector](https://github.com/fatihkahveci/game-server-selector)