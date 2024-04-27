using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



namespace Assets.Scripts.UI.Buttons
{
    internal class BrowseLobbyButton : MonoBehaviour
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
            await tcpClient.BrowseLobbies();
            Debug.Log("You have clicked the joinLobby button!");
        }


        
    }
}
