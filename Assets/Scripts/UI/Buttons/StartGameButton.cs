using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.UI.Buttons
{
    internal class StartGameButton : MonoBehaviour
      
    {
        public Button startGameButton;

        void Start()
        {
            Button btn = startGameButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {

            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene("URDL");
        }
    }
}
