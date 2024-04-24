using UnityEngine;
using UnityEngine.UI;

public class SpawnLobbyButton : MonoBehaviour
{
    public string lobbyName = "TEST LOBBY"; // Default lobby name
    public LobbyListManager lobbyListManager; // Reference to the LobbyListManager

    void Start()
    {
        // Get a reference to the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add a listener for when the button is clicked
        button.onClick.AddListener(AddLobbyToList);
    }

    void AddLobbyToList()
    {
        // Add the lobby name to the lobby list in LobbyListManager
        //lobbyListManager.AddLobby(lobbyName);
    }
}
