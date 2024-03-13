using UnityEngine;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using UnityEditor.PackageManager;
using System.Threading.Tasks;


public class TCPClient : MonoBehaviour
{
	private TcpClient _client;
	private NetworkStream _stream;
	private Thread _clientThread;


	public int port = 13000;
    public string hostAdress = "127.0.0.1";


	  void Start()
    {
         ConnectedToServer();
            
            }

    private void ConnectedToServer()
    {
        try { 
  
            _client = new TcpClient(hostAdress, port);
            _stream = _client.GetStream();
			Debug.Log("Connected to the server.");
		}
		catch (System.Exception e)
		{
			Debug.LogError("Socket error: " + e.Message);
		}
	}

	public void JoinLobby(string lobbyId, PlayerClient player)
	{
		if(lobbyId == null || player == null && _stream != null)
		{
			string message = $"JOIN,{lobbyId},{player.Id},{player.Name}";

			player.SendMessage(message);
		}
	}

    public void CreateLobby(PlayerClient player)
    {
        if ( player == null && _stream != null)
        {
            string message = $"Create,{player.Id},{player.Name}";

            player.SendMessage(message);
        }
    }
    private void OnApplicationQuit()
    {
        _stream?.Close();
        _client?.Close();
        _clientThread?.Abort();
    }

    private void OnDestroy()
    {
        OnApplicationQuit();
    }


}
