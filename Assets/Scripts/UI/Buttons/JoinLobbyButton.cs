using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{


    internal class JoinLobbyButton : MonoBehaviour


    {
        [SerializeField] InputField lobbyName;
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
            if(lobbyName.text.Length != 0)
            {
                await tcpClient.JoinLobby(GameManager.localPlayerId, lobbyName.text);
                Debug.Log("You have clicked the button!");
            } 
            else
            {
                Debug.Log("YOU HAVE TO ENTER A LOBBYNAME!!!");
            }
            
           // SceneManager.LoadScene("MultiplayerLobby");
            //tcpClient.ListenForServerMessages();
            
        }

    } 
}
