using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

public class MySignalRClient : MonoBehaviour
{
    private HubConnection connection;

    void Start()
    {
        // Initialize SignalR connection
        connection = new HubConnectionBuilder()
            .WithUrl("http://your-signalr-server-url")
            .Build();

        // Start the connection
        connection.StartAsync();

        // Listen for PlayerPositionUpdated messages from the server
        connection.On<string, float, float>("PlayerPositionUpdated", (connectionId, x, y) =>
        {
            // Handle the player position update here
        });
    }
}
