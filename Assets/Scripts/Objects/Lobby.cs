using System;

[Serializable]
public class Lobby
{
    public string LobbyId;
    public string LobbyName;
    public string CreatorName;
}

[Serializable]
public class Lobbies
{
    public Lobby[] lobbies;
}
