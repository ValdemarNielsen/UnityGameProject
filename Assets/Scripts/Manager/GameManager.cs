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
    public static int[,] HasVisitedRoom { get; set; } = new int[5,5];


    public static void UpdatePlayerPosition(int newRow, int newColumn)
    {
        GameManager.playerRowHolder = newRow;
        GameManager.playerColHolder = newColumn;
        HasVisitedRoom[newRow, newColumn] += 1;
    }

    // Check if the room has been visited
    public static bool HasVisited(int row, int column)
    {
        return HasVisitedRoom[row, column] == 1;
    }

    public static int[] GetPlayerPosition()
    {
        return new int[] { GameManager.playerRowHolder, GameManager.playerColHolder };
    }

}