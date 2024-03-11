using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

namespace Assets.Scripts
{
    public class ConnectToHubService : MonoBehaviour
    {

        private HubConnection hubConnection;
        async void Start()
        {

            try
            {
                hubConnection = new HubConnectionBuilder()
              
                    .WithUrl("https://localhost:7206/client-hub")
                    .Build();

                await hubConnection.StartAsync();
                Debug.Log("SignalR Connected!");

                // Register event handlers
                hubConnection.On<string>("ReceiveMessage", (message) =>
                {
                    Debug.Log($"Message from server: {message}");
                });
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while connecting to SignalR: {ex.Message}");
            }
        }

        void OnDestroy()
        {
            // Properly disconnect when the object is destroyed
            hubConnection?.StopAsync();
            hubConnection?.DisposeAsync();
        }
    }
        }
    
