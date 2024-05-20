using UnityEngine;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Text.Json;
using System.Net.Http;




public class TCPClient : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 spawnPoint;
    private TcpClient client;
    private NetworkStream stream;
    private LobbyListManager lobbyListManager;
    private PlayerMovement playerMovement;
    public static TCPClient Instance;



    public int port = 5010;
    public string hostAdress = "127.0.0.1";

    private void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
        
    }

    private async void Start()
    {
        
        Debug.Log("we got into start");
        try
        {
            client = new TcpClient(hostAdress, port);
            stream = client.GetStream();
            ListenForServerMessages();
            await client.ConnectAsync(hostAdress, port);            
            
        }
        catch (System.Exception e)
        {
            Debug.LogError("Socket error: " + e.Message);
        }

    }
  
    // Generate a unique player ID
    public string GeneratePlayerId()
    {
        // We can generate a unique ID based on various factors such as timestamp, GUID, etc.
        // Using timestamp:
        string playerId = DateTime.Now.ToString("ddHHmmssfff");

        return playerId;
    }

    public async Task SendTokenForValidation(string token)
    {
        if (client != null && stream != null)
        {

            try
            {
                Debug.Log("THIS IS THE PRE CLEANED TOKEN: " + token);
                
               // string cleanedToken = token.Replace("\"", "");
               // Console.WriteLine("Cleaned Token: " + cleanedToken);
                // Parse the JSON string
                var jsonDocument = JsonDocument.Parse(token);
                // Extract the token value
                string cleanedToken = jsonDocument.RootElement.GetProperty("token").GetString();
                Debug.Log("THIS IS THE AFTER CLEANED TOKEN: " + cleanedToken);

                // Send token to the server
                string message = cleanedToken;
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
/*
                // Read server's response
                byte[] receivedBytes = new byte[1024]; // Adjust buffer size as needed
                int bytesRead = await stream.ReadAsync(receivedBytes, 0, receivedBytes.Length);
                string receivedData = Encoding.UTF8.GetString(receivedBytes, 0, bytesRead);
                Debug.Log("TRYING TO SEND TOKEN FOR VALIDATION TEST STEP 1");

                Debug.Log("Received from server: " + receivedData);
                Debug.Log("TRYING TO SEND TOKEN FOR VALIDATION STEP TEST STEP 2");

                string[] dataParts = receivedData.Split(':');
                if (dataParts[0] == "playerID")
                {
                    GameManager.localPlayerId = dataParts[1];
                    Debug.Log("THIS IS OUT LOCAL PLAYER ID FROM SERVER: " + GameManager.localPlayerId);
                }*/

            }
            catch (Exception ex)
            {
                Debug.LogError("Error in CreateLobby: " + ex.Message);
            }
        }
    }

    // Method to create a lobby
    public async Task CreateLobby(string playerName, string lobbyName)
    {
        if (client != null && stream != null)
        {
            try
            {

                // Send "CREATE" message to the server
                await SendPlayerCreateAsync("CREATE", lobbyName, playerName, "{}");
              //  string message = $"CREATE,{GameManager.localPlayerId},{playerName},{lobbyName}";
              //  byte[] dataToSend = Encoding.UTF8.GetBytes(message);
             //   await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                /*
                // Read server's response
                byte[] receivedBytes = new byte[1024]; // Adjust buffer size as needed
                int bytesRead = await stream.ReadAsync(receivedBytes, 0, receivedBytes.Length);
                string receivedData = Encoding.UTF8.GetString(receivedBytes, 0, bytesRead);
                Debug.Log("Received from server: " + receivedData);   
                */
            }
            catch (Exception ex)
            {
                Debug.LogError("Error in CreateLobby: " + ex.Message);
            }
        }
    }

    public async Task LoginIntoAccount(string username, string password)
    {
        if (client != null && stream != null)
        {
            try
            {
               
                // Send "CREATE" message to the server
                string message = $"LOGIN,{username},{password}";
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);

                // Read server's response
                byte[] receivedBytes = new byte[1024]; // Adjust buffer size as needed
                int bytesRead = await stream.ReadAsync(receivedBytes, 0, receivedBytes.Length);
                string receivedData = Encoding.UTF8.GetString(receivedBytes, 0, bytesRead);
                Debug.Log("Received from server: " + receivedData);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error in LoginIntoAccount: " + ex.Message);
            }
        }
    }

    public async Task CreateUser(string realName, string email, string username, string password)
    {
        if (client != null && stream != null)
        {
            try
            {
                
                // Send "REGISTER" message to the server
                string message = $"REGISTER,,{realName},{email},{username},{password}";
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);

                // Read server's response
                byte[] receivedBytes = new byte[1024]; // Adjust buffer size as needed
                int bytesRead = await stream.ReadAsync(receivedBytes, 0, receivedBytes.Length);
                string receivedData = Encoding.UTF8.GetString(receivedBytes, 0, bytesRead);
                Debug.Log("Received from server: " + receivedData);
                string[] dataParts = receivedData.Split(':');
                if (dataParts[0] == "playerID")
                if (GameManager.localPlayerId == null)
                    {
                        {
                            GameManager.localPlayerId = dataParts[1];
                            Debug.Log(GameManager.localPlayerId);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                Debug.LogError("Error in CreateUser: " + ex.Message);
            }
        }
    }

    public async Task JoinLobby(string playerID, string lobbyName)
    {
        if (client != null && stream != null)
        {
            try
            {
                SceneManager.LoadScene("MultiplayerLobby");
                await SendPlayerJoinAsync("JOIN", lobbyName, playerID,"{}");

               // string joinMessage = $"JOIN,{GameManager.localPlayerId},Henrik";
               // byte[] dataToSend = Encoding.UTF8.GetBytes(joinMessage);
               // await stream.WriteAsync(dataToSend, 0, dataToSend.Length);

                Debug.Log("'JOIN'Lobby message sent to server.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred: {ex.Message}");
                // Handle the exception (log the error, show an error message to the user, etc.)
            }
        }
    }

    public async Task BrowseLobbies()
    {
        if (client != null && stream != null)
        {
            try
            {


                SceneManager.LoadScene("LobbyBrowse");
                //  return SendPlayerCommandAsync("LIST_LOBBIES")
                await SendPlayerCommandAsync("LIST_LOBBIES", GameManager.localPlayerId, "{}");
              //  string BrowseLobbiesMessage = $"LIST_LOBBIES";
              //  byte[] dataToSend = Encoding.UTF8.GetBytes(BrowseLobbiesMessage);
              //  await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred: {ex.Message}");
                // Handle the exception (log the error, show an error message to the user, etc.)
            }
        }


    }
   
    public async Task ListenForServerMessages()
    {
        byte[] buffer = new byte[1024];
        Debug.Log("Starting listeningForServerMessages");

        while (true)
        {
            try
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    Debug.Log("Server has closed the connection.");
                    break;
                }
                Debug.Log("Listening for a server message...");
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Debug.Log("Received from server: " + receivedData);

                try
                {
                    // Deserialize the JSON data directly into an array of Lobby objects
                    Lobby[] lobbies = System.Text.Json.JsonSerializer.Deserialize<Lobby[]>(receivedData);
                    if (lobbies != null && lobbies.Length > 0)
                    {
                        Debug.Log($"Total lobbies received: {lobbies.Length}");
                        foreach (Lobby lobby in lobbies)
                        {
                            Debug.Log($"Lobby found: ID = {lobby.LobbyId}, Name = {lobby.LobbyName}, Creator = {lobby.CreatorName}");
                            lobbyListManager.GenerateLobbyPanels(lobbies);
                        }
                    }
                    else
                    {
                        Debug.Log("No lobbies found in the received message.");
                    }
                }
                catch (System.Text.Json.JsonException jsonEx)
                {
                    Debug.Log("Not a lobby data message: " + jsonEx.Message + " Data: " + receivedData);
                    string[] dataParts = receivedData.Split(',');
                    if (dataParts[0] == "SPAWN_PLAYER")
                    {
                        SpawnPlayer(dataParts[1]);
                        Debug.Log("a spawn player signal has been detected.");
                    }
                    if (dataParts[0] == "REMOVE_PLAYER")
                    {
                        RemovePlayer(dataParts[1]);
                        Debug.Log("a remove player signal has been detected.");
                    }
                    if (dataParts[0] == "MOVEMENT")
                    {
                        await playerMovement.ExecuteCommandFromServer(dataParts[1], dataParts[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error receiving data: " + ex.Message);
                break;
            }
        }
    }


    public void SpawnPlayer(string playerId)
    {
        Debug.Log("a SpawnPlayer request was send to client");
        // Determine if this is the local player and set that as a variable under the prefab.
        if (playerId == GameManager.localPlayerId)
        {
            Debug.Log("A player with that Id already exists");
            // Perform any additional setup for the local player
        }
        else
        {
            // Instantiate the player prefab at the spawn point
            GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            // Assign the player ID to the spawned player (we might have to adjust this based on our player controller script)
            newPlayer.GetComponent<PlayerMovement>().PlayerId = playerId;
            // Setup for remote players if needed
            Debug.Log($"Player spawned with ID: {playerId}");
        }        
    }

    public void RemovePlayer(string playerId)
    {
        Debug.Log("RemovePlayer request received for player ID: " + playerId);

        // Find all PlayerMovement components in the scene
        PlayerMovement[] allPlayers = FindObjectsOfType<PlayerMovement>();

        // Iterate through all PlayerMovement components to find the one with the matching PlayerId
        foreach (PlayerMovement player in allPlayers)
        {
            if (player.PlayerId == playerId)
            {
                // Log the removal
                Debug.Log("Removing player with ID: " + playerId);

                // Destroy the player's GameObject
                Destroy(player.gameObject);
                return;
            }
        }

        // Log if the player was not found
        Debug.Log("Player with ID " + playerId + " not found.");
    }


    public async Task SendPlayerActionAsync(string actionType, string action, string playerId, string jsonData)
    {        
        if (client != null && stream != null)
        {
            try
            {
                var dataObject = new
                {
                    Command = actionType,
                    Input = action,
                    PlayerId = GameManager.localPlayerId,
                    Data = JsonConvert.DeserializeObject(jsonData)  // Assuming jsonData is a valid JSON string
                };

                string message = JsonConvert.SerializeObject(dataObject) + "\n"; // Adding newline at the end
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                Debug.Log($"action movement message: {message}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in send action: {ex.Message}");
            }
        }
    }

    public async Task SendPlayerCommandAsync(string actionType, string playerId, string jsonData)
    {
        if (client != null && stream != null)
        {
            try
            {
                var dataObject = new
                {
                    Command = actionType,
                    PlayerId = playerId,
                    Data = JsonConvert.DeserializeObject(jsonData)  // Assuming jsonData is a valid JSON string
                };

                string message = JsonConvert.SerializeObject(dataObject) + "\n"; // Adding newline at the end
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                Debug.Log($"Normal command message: {message}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in send action: {ex.Message}");
            }
        }
    }


    public async Task SendPlayerCreateAsync(string actionType, string lobbyName, string playerName, string jsonData)
    {
        if (client != null && stream != null)
        {
            try
            {
                var dataObject = new
                {
                    Command = actionType,
                    LobbyName = lobbyName,
                    PlayerName = playerName,
                    Data = JsonConvert.DeserializeObject(jsonData)  // Assuming jsonData is a valid JSON string
                };

                string message = JsonConvert.SerializeObject(dataObject) + "\n"; // Adding newline at the end
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                Debug.Log($"Create lobby message: {message}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in send action: {ex.Message}");
            }
        }
    }

    public async Task SendPlayerJoinAsync(string actionType, string lobbyName, string playerID, string jsonData)
    {
        if (client != null && stream != null)
        {
            try
            {
                var dataObject = new
                {
                    Command = actionType,
                    LobbyName = lobbyName,
                    PlayerName = playerID,
                    Data = JsonConvert.DeserializeObject(jsonData)  // Assuming jsonData is a valid JSON string
                };

                string message = JsonConvert.SerializeObject(dataObject) + "\n"; // Adding newline at the end
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                Debug.Log($"Create lobby message: {message}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in send action: {ex.Message}");
            }
        }
    }





    private void OnApplicationQuit()
    {
        stream?.Close();
        client?.Close();
    }

    private void OnDestroy()
    {
        OnApplicationQuit();
    }


}
