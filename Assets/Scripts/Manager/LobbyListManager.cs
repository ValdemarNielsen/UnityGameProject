using UnityEngine;

public class LobbyListManager : MonoBehaviour
{
    // Example JSON string
    private string jsonString = "[{\"LobbyId\":\"64299bd9-55a4-4c99-b278-5c629df473eb\",\"LobbyName\":\"Henrik's Lobby\",\"CreatorName\":\"Henrik\"}]";

    void Start()
    {
        ParseLobbyData(jsonString);
    }

    void ParseLobbyData(string json)
    {
        // Since JsonUtility does not directly support top-level arrays, we wrap the array in an object
        string wrappedJson = "{\"lobbies\":" + json + "}";
        Lobbies lobbies = JsonUtility.FromJson<Lobbies>(wrappedJson);

        // Example: Accessing the first lobby's data
        if (lobbies.lobbies.Length > 0)
        {
            Debug.Log("First Lobby Name: " + lobbies.lobbies[0].LobbyName);
            Debug.Log("First Creator Name: " + lobbies.lobbies[0].CreatorName);
        }

        // Here, you could call a method to generate UI elements for each lobby
        // For example: GenerateLobbyButtons(lobbies.lobbies);
    }
}
