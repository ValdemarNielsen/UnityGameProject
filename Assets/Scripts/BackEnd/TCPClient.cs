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
using JetBrains.Annotations;


public class TCPClient : MonoBehaviour
{

    private TcpClient client;
	private NetworkStream stream;
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