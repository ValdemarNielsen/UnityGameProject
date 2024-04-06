using UnityEngine;
using UnityEngine.SceneManagement;
using SceneManagement;
using GameProject.Services;

public class MazeManager : MonoBehaviour
{
    private int mazeSize = GameManager.mazeSize;
    void Start()
    {
        if (GameManager.MazeHolder == null)
        {
            // insert 
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
