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
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneManagement;
using GameProject.Services;


namespace Assets.Scripts.UI.Buttons
{
    internal class CreateLobbyButton : MonoBehaviour


    {
        private TCPClient tcpClient;
        private Button createLobby;

        void Start()
        {
            Button btn = createLobby.GetComponent<Button>();
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
