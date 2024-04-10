using UnityEngine.SceneManagement;
using UnityEngine;
// Your LobbyListManager should access the data from LobbyDataHolder
public class LobbyListManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrefab; // Assign this in the inspector
    [SerializeField] private Transform contentParent; // Assign the "Content" transform in the inspector

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (LobbyDataHolder.Instance != null && LobbyDataHolder.Instance.Lobbies != null)
        {
            GenerateLobbyPanels(LobbyDataHolder.Instance.Lobbies);
        }
    }

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
