using GameProject.Models;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public static class GameManager
{
    public static Maze MazeHolder { get; set; }

    public static int playerRowHolder { get; set; }

    public static int playerColHolder { get; set; }

    public static Vector2 spawnPoint { get; set; }

    public static void UpdatePlayerPosition(int newRow, int newColumn)
    {
        GameManager.playerRowHolder = newRow;
        GameManager.playerColHolder = newColumn;
    }

    public static int[] GetPlayerPosition()
    {
        return new int[] { GameManager.playerRowHolder, GameManager.playerColHolder };
    }


    // TCP PlayerClient and not player
    private static PlayerClient currentPlayer = null;

    public static PlayerClient CurrentPlayer
    {
        get
        {
            if (currentPlayer == null)
            {
                // Lazy initialization of the PlayerClient
                currentPlayer = new PlayerClient("Bobby", new TcpClient());
            }
            return currentPlayer;
        }

    }
}