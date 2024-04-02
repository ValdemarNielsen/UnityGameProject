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
	private TcpClient client;
	private NetworkStream stream;
   // public GameObject PlayerPrefab;
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

    public async Task CreateLobby()
    {


        if (client != null)
        {
            Debug.Log("YOu got this far");
            try {

                Debug.Log("Inside TCP Call");
                string message = $"CREATE,{2},Henrik";


                byte[] dataToSend = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);


                //.SendMessage(message);

                byte[] receivedBytes = new byte[1024]; // Adjust buffer size as needed
                int bytesRead = await stream.ReadAsync(receivedBytes, 0, receivedBytes.Length);
                string receivedData = Encoding.UTF8.GetString(receivedBytes, 0, bytesRead);

                // Process the server's response
                Debug.Log("Received from server: " + receivedData);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error in CreateLobby: " + ex.Message);
            }
        }
    }

    /*
    private async void SendPlayerData(Vector2 playerPosition)
    {
        try
        {
            if (client != null && stream != null)
            {
                // Serialize coordinates to JSON
                string json = JsonUtility.ToJson(new { playerId = playerId, x = playerPosition.x, y = playerPosition.y });

                // Send JSON string over TCP
                byte[] dataToSend = Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error sending player data: " + ex.Message);
        }
    }

    private async void StartReceivingPlayerData()
    {
        try
        {
            if (client != null && stream != null)
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // Deserialize received data
                    // Note: We may need to implement your own deserialization logic here
                    // For example, JsonUtility.FromJson<MyPlayerData>(receivedData);
                    // Where MyPlayerData could be a class representing the received player data
                    Debug.Log("Received from server: " + receivedData);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error receiving player data: " + ex.Message);
        }
    }
    */

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
