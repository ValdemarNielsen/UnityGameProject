using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

// Your LobbyListManager should access the data from LobbyDataHolder
public class LobbyListManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab; // Assign this in the inspector
    [SerializeField] private Transform contentParent; // Assign the "Content" transform in the inspector

    public void GenerateLobbyPanels(Lobby[] lobbies)
    {
        // Clear previous panels
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Create a new button for each lobby
        foreach (Lobby lobby in lobbies)
        {
            GameObject button = Instantiate(buttonPrefab, contentParent);
            // Assuming your button prefab has text elements named accordingly
            button.transform.Find("LobbyIdText").GetComponent<Text>().text = lobby.LobbyId;
            button.transform.Find("LobbyNameText").GetComponent<Text>().text = lobby.LobbyName;
            button.transform.Find("CreatorNameText").GetComponent<Text>().text = lobby.CreatorName;
        }
    }
}