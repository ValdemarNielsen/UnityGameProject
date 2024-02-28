using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject.Models;

public class MazeNavigator : MonoBehaviour
{
    private MazeManager mazeManager;
    public Maze maze; // Assign in the MazeManager (from unity inspector, i think). 
    public int currentX = 2; // Starting X position in the maze
    public int currentY = 2; // Starting Y position in the maze

    void Start()
    {
       /* Debug.Log("MazeManager instance is found");
        mazeManager = FindObjectOfType<MazeManager>(); // This should now work
        if (mazeManager != null)
        {
            maze = mazeManager.maze; // Assign the maze from the mazeManager
        }
        else
        {
            Debug.LogError("MazeManager instance not found in the scene.");
        } */
    }
}
