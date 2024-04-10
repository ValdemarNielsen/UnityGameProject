using UnityEngine.SceneManagement;
using UnityEngine;
// Your LobbyListManager should access the data from LobbyDataHolder
public class LobbyListManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrefab; // Assign this in the inspector
    [SerializeField] private Transform contentParent; // Assign the "Content" transform in the inspector
}