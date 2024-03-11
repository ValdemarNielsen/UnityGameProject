/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Services
{
    public class BroadcastServices : IBroadcastService, IInitializable
    {
        private const string ServerAddress = "https://localhost:xxxx";
        private const string Hub = "/NotificationHub";

        private HubConnection _connection;
        public event Action<string> OnMessageReceived;

        public async void Initialize()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(ServerAddress + Hub) // hubConnectionBuilder
                .Build(); // hubConnection
            _connection.On("OnMessageReceived", (string message) =>
            {
                OnMessageReceived?.Invoke(message);
            });
        }

        public async Task BroadcastMessage(string message)
        {
            await _connection.SendAsync("BroadcastMessage", message);
        }
    }
}
*/