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


namespace Assets.Scripts.UI.Buttons
{
    internal class CreateLobbyButton : MonoBehaviour


    {
        public TCPClient tcpClient;
        public Button createLobby;

        void Start()
        {
            Button btn = createLobby.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        public void TaskOnClick()
        {
            tcpClient.CreateLobby();
            Debug.Log("You have clicked the button!");
            Console.WriteLine("test");
        }

    }
}
