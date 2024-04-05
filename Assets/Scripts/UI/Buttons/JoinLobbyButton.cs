using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;
using Assets;
using SceneManagement;
using GameProject.Services;


namespace Assets.Scripts.UI.Buttons
{
    internal class JoinLobbyButton : MonoBehaviour


    {
        private TCPClient tcpClient;
        private Button joinLobby;

        void Start()
        {
            Button btn = joinLobby.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        public async void TaskOnClick()
        {
            await tcpClient.CreateLobby();
            Debug.Log("You have clicked the button!");
            Console.WriteLine("test");
            //tcpClient.ListenForServerMessages();
            //SceneManager.LoadScene("Lobby");
            if (GameManager.localPlayerId == null)
            {
                GameManager.localPlayerId = tcpClient.GeneratePlayerId();
            }
        }

    }
}
