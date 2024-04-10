using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrefab; // Assign this in the inspector
    [SerializeField] private Transform contentParent; // Assign the "Content" transform in the inspector

    // Call this method when you receive your lobby data
    public void GenerateLobbyPanels(Lobby[] lobbies)
    {
        // Clear previous panels
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Create a new panel for each lobby
        foreach (Lobby lobby in lobbies)
        {
            GameObject panel = Instantiate(panelPrefab, contentParent);

            // Assuming your panel prefab has text elements named accordingly
            panel.transform.Find("LobbyIdText").GetComponent<Text>().text = lobby.LobbyId;
            panel.transform.Find("LobbyNameText").GetComponent<Text>().text = lobby.LobbyName;
            panel.transform.Find("CreatorNameText").GetComponent<Text>().text = lobby.CreatorName;
        }
    }
}
