using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{
    internal class MultiplayerButton : MonoBehaviour
    {
        private Button MultiPlayerButton;

        void Start()
        {
            MultiPlayerButton = GetComponent<Button>();
            MultiPlayerButton.onClick.AddListener(TaskOnClick);
        }

        public void TaskOnClick()
        {
            GameManager.multiPlayer = true;
            Debug.Log("You have clicked Single player button");
            SceneManager.LoadScene("CreateUserScene");

        }
    }
}
