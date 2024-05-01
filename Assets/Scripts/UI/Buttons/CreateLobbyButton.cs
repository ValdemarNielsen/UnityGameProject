using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.UI.Buttons
{
    internal class CreateLobbyButton : MonoBehaviour
    {
        private TCPClient tcpClient;
        private Button createLobby;

        void Start()
        {
            createLobby = GetComponent<Button>();
            createLobby.onClick.AddListener(TaskOnClick);
            tcpClient = FindObjectOfType<TCPClient>();
        }

        public async void TaskOnClick()
        {
            //await tcpClient.CreateLobby();
            Debug.Log("You have clicked the CreateLobbyButton!");
            //tcpClient.ListenForServerMessages();
            if (GameManager.localPlayerId == null)
            {
                GameManager.localPlayerId = tcpClient.GeneratePlayerId();
            }
            SceneManager.LoadScene("CreateLobby");
            
        }
    }
}
