using UnityEngine;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using GameProject.Models;
using System.Text.Json;



public class TCPClient : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 spawnPoint;
    private TcpClient client;
    private NetworkStream stream;
    public LobbyListManager lobbyListManager;
    // public string playerId; // Unique ID for the player


    

    public int port = 13000;
    public string hostAdress = "127.0.0.1";
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Awake()
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
            
            Debug.Log("Connected to the server.");
            
        }
        catch (System.Exception e)
        {
            Debug.LogError("Socket error: " + e.Message);
        }

    }
        
    // Generate a unique player ID
    public string GeneratePlayerId()
    {
        // You can generate a unique ID based on various factors such as timestamp, GUID, etc.
        // Here's an example using timestamp:
        string playerId = DateTime.Now.ToString("ddHHmmssfff");

        return playerId;
    }

    // Method to create a lobby
    public async Task CreateLobby(string playerName, string lobbyName)
    {
        if (client != null && stream != null)
        {
            try
            {
                // Ensure there's a player ID generated and assigned.
                if (GameManager.localPlayerId == null)
                {
                    GameManager.localPlayerId = GeneratePlayerId();
                }
                // Send "CREATE" message to the server
                string message = $"CREATE,{GameManager.localPlayerId},{playerName},{lobbyName}";
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
                Debug.LogError("Error in CreateLobby: " + ex.Message);
            }
        }
    }

    public async Task JoinLobby()
    {
        if (client != null && stream != null)
        {
            try
            {              
                // Ensure there's a player ID generated and assigned.
                if (GameManager.localPlayerId == null)
                {
                    GameManager.localPlayerId = GeneratePlayerId();
                }

                string joinMessage = $"JOIN,{GameManager.localPlayerId},Henrik";
                byte[] dataToSend = Encoding.UTF8.GetBytes(joinMessage);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);

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

                if (GameManager.localPlayerId == null)
                {
                    GameManager.localPlayerId = GeneratePlayerId();
                }

                string BrowseLobbiesMessage = $"LIST_LOBBIES";
                byte[] dataToSend = Encoding.UTF8.GetBytes(BrowseLobbiesMessage);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
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
                    Lobby[] lobbies = JsonSerializer.Deserialize<Lobby[]>(receivedData);
                    if (lobbies != null && lobbies.Length > 0)
                    {
                        Debug.Log($"Total lobbies received: {lobbies.Length}");
                        foreach (Lobby lobby in lobbies)
                        {
                            Debug.Log($"Lobby found: ID = {lobby.LobbyId}, Name = {lobby.LobbyName}, Creator = {lobby.CreatorName}");
                            // Additional logic to handle the lobby data, e.g., update UI

                        }
                    }
                    else
                    {
                        Debug.Log("No lobbies found in the received message.");
                    }
                }
                catch (JsonException jsonEx)
                {
                    Debug.Log("Not a lobby data message: " + jsonEx.Message + " Data: " + receivedData);
                    // If parsing fails, it wasn't lobby data. Handle other message types.
                    string[] dataParts = receivedData.Split(',');
                    if (dataParts[0] == "SPAWN_PLAYER")
                    {
                        SpawnPlayer(dataParts[1]);
                    }

                    // Add more cases for other types of messages if needed
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
            newPlayer.GetComponent<PlayerController>().PlayerId = playerId;
            // Setup for remote players if needed
            Debug.Log($"Player spawned with ID: {playerId}");
        }        
    }


    public async Task SendPlayerActionAsync(string actionType, string playerId, string jsonData)
    {
        Debug.Log("Entered the send player action method");
        if (client != null && stream != null)
            try
            {

                string message = $"{actionType},{playerId},{jsonData}";
                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                Debug.Log("action message: " + message + "data to send: " + dataToSend);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error in send action: " + ex.Message);
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
