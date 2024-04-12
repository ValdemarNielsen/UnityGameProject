using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartLobbyButton : MonoBehaviour
{

    [SerializeField] InputField playerName;
    [SerializeField] InputField lobbyName;
    [SerializeField] InputField messageTextField;
    private TCPClient tcpClient;
    private Button startLobby;
    private TextMesh playerNameText;



    // Start is called before the first frame update
    void Start()
    {
        startLobby = GetComponent<Button>();
        startLobby.onClick.AddListener(TaskOnClick);
        tcpClient = FindObjectOfType<TCPClient>();
    }

   

    public async void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");

        if (playerName.text.Length != 0 && lobbyName.text.Length != 0 || lobbyName.text != "Lobby Name..." || playerName.text != "Player Name...")
        {
            messageTextField.text = "";
            await tcpClient.CreateLobby(playerName.text, lobbyName.text);
            Console.WriteLine("Playername and lobbyname was filled");
            //tcpClient.ListenForServerMessages();
            if (GameManager.localPlayerId == null)
            {
                GameManager.localPlayerId = tcpClient.GeneratePlayerId();
            }
            //SceneManager.LoadScene("LobbyBrowse");
        }
        else
        {

            // Change the color of the text
            messageTextField.textComponent.color = Color.red;
            // Display message in the TextMeshPro Input Field
            messageTextField.text = "Please fill out all fields!!!";
            return; // Exit the method if data is not filled
            }
        }





    }
