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
                      
            tcpClient.JoinLobby();
            Debug.Log("You have clicked the button!");
           // SceneManager.LoadScene("MultiplayerLobby");
            //tcpClient.ListenForServerMessages();
            
        }

    } 
}
