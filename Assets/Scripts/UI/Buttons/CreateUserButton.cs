using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CreateUserButton : MonoBehaviour
{

    [SerializeField] InputField realName;
    [SerializeField] InputField username;
    [SerializeField] InputField email;
    [SerializeField] InputField password;
    [SerializeField] InputField messageTextField;



    private TCPClient tcpClient;
    private Button CreateUser;



    // Start is called before the first frame update
    void Start()
    {        
        CreateUser = GetComponent<Button>();
        CreateUser.onClick.AddListener(TaskOnClick);
        tcpClient = FindObjectOfType<TCPClient>();
    }



    public async void TaskOnClick()
    {
        
        if (realName.text.Length != 0 && username.text.Length != 0 && email.text.Length != 0 && password.text.Length != 0)
        {
            
            await tcpClient.CreateUser(realName.text, email.text, username.text, password.text);
            Console.WriteLine("realName, username, email and password was filled");
            //tcpClient.ListenForServerMessages();
            
            SceneManager.LoadScene("LoginScene");

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

