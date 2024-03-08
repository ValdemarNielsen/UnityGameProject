using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class GameHub : Hub
{
    // Dictionary to store player positions
    private static Dictionary<string, Vector2> playerPositions = new Dictionary<string, Vector2>();

    // This method will be called when a client connects to the hub
    public override async Task OnConnectedAsync()
    {
        // Perform any necessary logic when a client connects
        await base.OnConnectedAsync();
    }

    // This method will be called when a client disconnects from the hub
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        // Remove the player's position when they disconnect
        playerPositions.Remove(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    // Method to update player position
    public async Task UpdatePlayerPosition(float x, float y)
    {
        // Store the player's position
        playerPositions[Context.ConnectionId] = new Vector2(x, y);

        // Broadcast the updated player position to all other clients
        await Clients.Others.SendAsync("PlayerPositionUpdated", Context.ConnectionId, x, y);
    }
}
