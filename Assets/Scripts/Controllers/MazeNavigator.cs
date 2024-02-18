using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject.Models;

public class MazeNavigator : MonoBehaviour
{
    private MazeManager mazeManager;
    public Maze maze; // Assign in the MazeManager (from unity inspector, i think). 
    public int currentX = 3; // Starting X position in the maze
    public int currentY = 3; // Starting Y position in the maze

    void Start()
    {
        mazeManager = FindObjectOfType<MazeManager>(); // This should now work
        if (mazeManager != null)
        {
            maze = mazeManager.maze; // Assign the maze from the mazeManager
        }
        else
        {
            Debug.LogError("MazeManager instance not found in the scene.");
        }
    }

    // Method to move the player through the maze
    public void Move(string direction)
    {   
        if (maze == null || maze.Rooms == null || currentX < 0 || currentX >= maze.Rooms.GetLength(0) || currentY < 0 || currentY >= maze.Rooms.GetLength(1))
        {
            Debug.LogError("MazeNavigator: Invalid maze configuration or position.");
            return;
        }

        Room currentRoom = maze.Rooms[currentX, currentY];
        switch (direction)
        {
            case "Up":
                if (currentRoom.Up && currentY > 0) currentY--;
                break;
            case "Down":
                if (currentRoom.Down && currentY < maze.Rooms.GetLength(1) - 1) currentY++;
                break;
            case "Left":
                if (currentRoom.Left && currentX > 0) currentX--;
                break;
            case "Right":
                if (currentRoom.Right && currentX < maze.Rooms.GetLength(0) - 1) currentX++;
                break;
            default:
                Debug.LogError("MazeNavigator: Invalid movement direction.");
                break;
        }

        // Feedback to player about the move - Might be implemented later
        /// Debug.Log($"Player moved to room at {currentX}, {currentY}. Current room has doors: Up={currentRoom.Up}, Down={currentRoom.Down}, Left={currentRoom.Left}, Right={currentRoom.Right}");
    }

    // Example method to connect to UI buttons
    public void MovePlayerUp()
    {
        Move("Up");
    }

    public void MovePlayerDown()
    {
        Move("Down");
    }

    public void MovePlayerLeft()
    {
        Move("Left");
    }

    public void MovePlayerRight()
    {
        Move("Right");
    }
}
