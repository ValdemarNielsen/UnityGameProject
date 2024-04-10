using System;

[Serializable]
public class Lobby
{
    public string LobbyId { get; set; }
    public string LobbyName { get; set; }
    public string CreatorName { get; set; }
}

[Serializable]
public class Lobbies
{
    public Lobby[] lobbies;
}
