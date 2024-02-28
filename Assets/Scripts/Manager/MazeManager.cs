using GameProject.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneManagement;
using GameProject.Services;

public class MazeManager : MonoBehaviour
{
    public int mazeSize = 5;

    void Start()
    {
        if (GameManager.MazeHolder == null)
        {
            MazeGeneratorService mazeGeneratorService = new MazeGeneratorService(mazeSize);
            GameManager.MazeHolder = mazeGeneratorService.GenerateMaze();
            SceneManagements.AssignScenesToRooms(GameManager.MazeHolder);
            Debug.Log($"Loaded maze. printing maze {GameManager.MazeHolder}");
            // initialize players position at the center of the maze.
            GameManager.playerRowHolder = mazeSize / 2;
            GameManager.playerColHolder = mazeSize / 2;
            SceneManager.LoadScene(GameManager.MazeHolder.Rooms[GameManager.playerRowHolder, GameManager.playerColHolder].SceneName);
        }
        else
        {
            Debug.Log("Maze is already generated");
        }
    }

    
}
