/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Assets.Scripts.BackEnd
{
    using UnityEngine;
    

    public class WebSocketClient : MonoBehaviour
    {
        private WebSocket ws;

        void Start()
        {
            // Replace "ws://your-backend-url/websocket" with the URL of your backend WebSocket endpoint
            // Replace "172.21.16.76" with your local IP address
            // Replace "port" with the port number on which your backend WebSocket server is running
            // Port is set at 8080 as that might be default. 
            ws = new WebSocket("ws://172.21.16.76:port/8080");

            ws.OnOpen += (sender, e) =>
            {
                Debug.Log("WebSocket connected");
            };

            ws.OnMessage += (sender, e) =>
            {
                Debug.Log("Received message: " + e.Data);
            };

            ws.OnError += (sender, e) =>
            {
                Debug.LogError("WebSocket error: " + e.Message);
            };

            ws.OnClose += (sender, e) =>
            {
                Debug.Log("WebSocket closed");
            };

            ws.Connect();
        }

        void Update()
        {
            // Example of sending a message to the backend
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ws.Send("Hello from Unity!");
            }
        }

        void OnDestroy()
        {
            if (ws != null)
            {
                ws.Close();
            }
        }
    }

}
*/