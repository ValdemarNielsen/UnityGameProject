using UnityEngine;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using UnityEditor.PackageManager;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using GameProject.Models;



public class TCPClient : MonoBehaviour
{

    public GameObject playerPrefab;
    public Vector3 spawnPoint;
    private TcpClient client;
	private NetworkStream stream;
   // public string playerId; // Unique ID for the player




    public int port = 13000;
    public string hostAdress = "127.0.0.1";




    private async void Start()
    {

        Debug.Log("we got into start");
        try
        {

            client = new TcpClient(hostAdress, port);
            stream = client.GetStream();
            await client.ConnectAsync(hostAdress, port);
            Debug.Log("Connected to the server.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Socket error: " + e.Message);
        }

    }

    private async void Update()
    {
       
    }

    private async void ConnectedToServer()
    {

	}
    /*
    // Call this method when the player performs an action or moves. That could be sending ones location or action done shown as below. 
    // Call this instead of each method individually. 
    public void OnPlayerAction(Vector2 playerPosition)
    {
       // SendPlayerData(playerPosition);
    }
    */

	public void JoinLobby(string lobbyId, PlayerClient player)
	{
		if(lobbyId == null || player == null && stream != null)
		{
			string message = $"JOIN,{lobbyId},{player.Id},{player.Name}";

			player.SendMessage(message);
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
    public async Task CreateLobby()
    {
        if (client != null && stream != null)
        {
            try
            {
                // Generate a player ID
                string playerId = GeneratePlayerId();

                // Send "CREATE" message to the server
                string message = $"CREATE,{playerId},Henrik"; // Assuming "Henrik" is the player name
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
    public async Task ListenForServerMessages()
    {
        byte[] buffer = new byte[1024];
        int bytesRead;
        while (true)
        {
            try
            {
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Debug.Log("Received from server: " + receivedData);

                // Parse the received data
                string[] dataParts = receivedData.Split(',');
                Debug.Log("This is the Data received "+dataParts[0]);
                if (dataParts[0] == "SPAWN_PLAYER")
                {
                    string playerId = dataParts[1];
                    SpawnPlayer(playerId);
                }
                // Add more cases for other types of messages if needed
            }
            catch (Exception ex)
            {
                Debug.LogError("Error receiving data: " + ex.Message);
                break;
            }
        }
    }

    private void SpawnPlayer(string playerId)
    {
        // Instantiate the player prefab at the spawn point
        GameObject newPlayer = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        // Assign the player ID to the spawned player (you might have to adjust this based on our player controller script)
        newPlayer.GetComponent<PlayerController>().PlayerId = playerId;

        // Determine if this is the local player and set that as a variable under the prefab.
        if (playerId == GameManager.localPlayerId)
        {
            // Perform any additional setup for the local player
        }
        else
        {
            // Setup for remote players if needed
        }
        Debug.Log($"Player spawned with ID: {playerId}");
    }

    public async Task SendPlayerActionAsync(string playerId, string actionType, string jsonData)
    {
        if (client != null && stream != null)
        {
            string message = $"{playerId},{actionType},{jsonData}"; // Format as needed
            byte[] dataToSend = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
            Debug.Log("action message: " + message + "data to send: " + dataToSend);
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
