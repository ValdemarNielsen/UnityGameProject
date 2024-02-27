using GameProject.Models;
using GameProject.Services;
using RoomManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MazeData : MonoBehaviour
{
    public static Maze maze;
    // Reference to the RoomManager GameObject in the scene
    public RoomManager roomManager;

    void Start() // Change from Awake to Start
    {
        Debug.Log("This is MazeData being called");
        if (maze == null) // Generate only if not already created
        {
            MazeGeneratorService mazeGenerator = new MazeGeneratorService(5);
            maze = mazeGenerator.GenerateMaze();
            // Assign scenes to rooms using the RoomManager component
            roomManager.AssignScenesToRooms(maze);
            Debug.Log("This is part of the MazeData is also being called");

        }
    }
}