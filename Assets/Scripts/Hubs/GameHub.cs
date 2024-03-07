/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using Microsoft.AspNetCore.SignalR;
using GameProject.Models;
using System.Threading.Tasks;

namespace Assets.Scripts.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendPlayerLocation(Player location)
        {
            // Process player location data as needed
            // For example, broadcast it to all clients
            await Clients.All.SendAsync("ReceivePlayerLocation", location);
        }
    }
}
*/