using GameProject.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public int mazeSize = 5;
    public Maze maze { get; private set; }
    private int playerRow;
    private int playerCol;

    void Start()
    {
        maze = new Maze(mazeSize);

        // initialize players position at the center of the maze.
        playerRow = mazeSize / 2;
        playerCol = mazeSize / 2;
        
    }

    public void UpdatePlayerPosition(int newRow, int newColumn)
    {
        playerRow = newRow;
        playerCol = newColumn;
    }

    public int[] GetPlayerPosition()
    {
        return new int[] { playerRow, playerCol };
    }
}
