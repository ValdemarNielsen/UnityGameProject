using GameProject.Models;
using UnityEngine;

public static class GameManager
{
    public static int mazeSize = 5;
    public static Maze MazeHolder { get; set; }

    public static int playerRowHolder { get; set; }

    public static int playerColHolder { get; set; }

    public static Vector2 spawnPoint { get; set; }

    public static int[,] hasKilled { get; set; } = new int[5, 5];

    public static string localPlayerId { get; set; }

    public static bool multiPlayer = true; // { get; set; }

    public static string sceneName { get; set; }

    public static int pointScore { get; set; }

    public static string token { get; set; }
    public static void UpdatePlayerPosition(int newRow, int newColumn)
    {
        GameManager.playerRowHolder = newRow;
        GameManager.playerColHolder = newColumn;
    }

    public static int[] GetPlayerPosition()
    {
        return new int[] { GameManager.playerRowHolder, GameManager.playerColHolder };
    }
}
