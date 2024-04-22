using UnityEngine;
using System.Net.Sockets;
/*
public class PlayerClientManager : MonoBehaviour
{
    public static PlayerClientManager Instance { get; private set; }
    private PlayerClient playerClient;

    public PlayerClientManager(PlayerClient playerClient)
    {
        this.playerClient = playerClient;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(enemyGameObject);

            // Initialize the PlayerClient with example values
            playerClient = new PlayerClient( "Bobby", new TcpClient());
        }
        else
        {
            Destroy(enemyGameObject);
        }
    }

    public void CreateLobby()
    {
        string playerDataJson = playerClient.SerializeToJson();
        CreateLobby();
    }
}*/