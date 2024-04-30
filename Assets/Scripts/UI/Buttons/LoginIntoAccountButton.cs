using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;



public class LoginIntoAccountButton : MonoBehaviour
{

    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] InputField messageTextField;



    private TCPClient tcpClient;
    private Button LoginButton;



    // Start is called before the first frame update
    void Start()
    {
        LoginButton = GetComponent<Button>();
        LoginButton.onClick.AddListener(TaskOnClick);
        tcpClient = FindObjectOfType<TCPClient>();
    }



    public async void TaskOnClick()
    {

        if (username.text.Length != 0 && password.text.Length != 0)
        {
            if (GameManager.localPlayerId == null)
            {
                GameManager.localPlayerId = tcpClient.GeneratePlayerId();
            }
            await tcpClient.LoginIntoAccount(username.text, password.text);
            Console.WriteLine("realName, username, email and password was filled");
            //tcpClient.ListenForServerMessages();

            SceneManager.LoadScene("InitialLobbyScene");

        }
        else
        {
            Debug.Log("You have clicked the button! but the data is not filled");


            // Change the color of the text
            messageTextField.textComponent.color = Color.red;
            // Display message in the TextMeshPro Input Field
            messageTextField.text = "Please fill out all fields!!!";
            return; // Exit the method if data is not filled
        }
    }





}
