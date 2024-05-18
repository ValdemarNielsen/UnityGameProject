using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Net;



public class LoginIntoAccountButton : MonoBehaviour
{

    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] InputField messageTextField;



    private TCPClient tcpClient;
    private Button LoginButton;
    private readonly HttpClientService httpClientService = new HttpClientService();
    private readonly AuthenticationManager authenticationManager = new AuthenticationManager();




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
            
            LoginModel login = new LoginModel
            {
                Username = username.text,
                Password = password.text
            };

            // Call the LoginAsync method of the AuthenticationManager
            string token = await authenticationManager.LoginAsync(login);


            if (!string.IsNullOrEmpty(token))
            {
                GameManager.token = token;
                Debug.Log("Login successful!");
                await tcpClient.SendTokenForValidation(token);

                // Save the token or handle authentication as needed
                // 
                SceneManager.LoadScene("InitialLobbyScene");
            }
            else
            {
                Debug.LogError("Failed to log in. Username or password incorrect. No token aquired");
            }



            // await tcpClient.LoginIntoAccount(username.text, password.text);
            //tcpClient.ListenForServerMessages();

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
