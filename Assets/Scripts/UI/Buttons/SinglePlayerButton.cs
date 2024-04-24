using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{
    internal class SingleplayerButon : MonoBehaviour
    {
        private Button SinglePlayerButton;

        void Start()
        {
            SinglePlayerButton = GetComponent<Button>();
            SinglePlayerButton.onClick.AddListener(TaskOnClick);
        }

        public void TaskOnClick()
        {
            Debug.Log("You have clicked Single player button");
            SceneManager.LoadScene("Lobby");

        }
    }
}
