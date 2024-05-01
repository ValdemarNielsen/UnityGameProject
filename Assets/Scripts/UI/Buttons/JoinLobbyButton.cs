using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{


    internal class JoinLobbyButton : MonoBehaviour


    {
        private TCPClient tcpClient;
        private Button joinLobby;

        void Start()
        {
            joinLobby = GetComponent<Button>();
            joinLobby.onClick.AddListener(TaskOnClick);
            tcpClient = FindObjectOfType<TCPClient>();
        }

        public async void TaskOnClick()
        {
            if (GameManager.localPlayerId == null)
            {
                GameManager.localPlayerId = tcpClient.GeneratePlayerId();
            }
            if (tcpClient.playerPrefab == null)
            {
                Debug.LogError("Player prefab is not assigned.");
                return;
            }
            tcpClient.JoinLobby();
            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene("MutiplayerLobby");
            //tcpClient.ListenForServerMessages();
            
        }

    } 
}
