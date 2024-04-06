using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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
            await tcpClient.JoinLobby();
            Debug.Log("You have clicked the joinLobby button!");
        }


        // IMPORTANT: BELOW IS MADE INTO SPAWN PLAYER PREFAB TEMPORARILY !!! 

        /*
         *internal class JoinLobbyButton : MonoBehaviour


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
                if (tcpClient.playerPrefab == null)
                {
                    Debug.LogError("Player prefab is not assigned.");
                    return;
                }
                tcpClient.SpawnPlayer("12345");
                Debug.Log("You have clicked the button!");
                //tcpClient.ListenForServerMessages();
                if (GameManager.localPlayerId == null)
                {
                    GameManager.localPlayerId = tcpClient.GeneratePlayerId();
                }
            }

        } */
    }
}
