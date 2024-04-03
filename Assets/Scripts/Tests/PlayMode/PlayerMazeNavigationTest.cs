using NUnit.Framework;
using UnityEngine;
using GameProject.Models;
using System.Collections.Generic;
using UnityEngine.Assertions;
using Assert = NUnit.Framework.Assert;
using GameProject.Services;
using UnityEngine.SceneManagement;
using SceneManagement;



[TestFixture]
public class PlayerMazeNavigationTest
{
    private Maze _maze;

    [SetUp]
    public void Setup()
    {
        int mazeSize = 5;
        
        if (GameManager.MazeHolder == null)
        {
            MazeGeneratorService mazeGeneratorService = new MazeGeneratorService(mazeSize);
            GameManager.MazeHolder = mazeGeneratorService.GenerateMaze();
            SceneManagements.AssignScenesToRooms(GameManager.MazeHolder);
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

    [Test]
    public void PlayerMovesRight_UpdatesPositionCorrectly()
    {
        // Arrange
        var expectedRow = 2;
        var expectedColumn = 3; // Expecting to move to the right
        var beforePosition = GameManager.GetPlayerPosition();
        Debug.Log("Position before: " + beforePosition[0] +", " + beforePosition[1]);
        Debug.Log("Expected new position: 2, 3");
        // Act
        // Simulate the right door transition
        // This part might need adjustment based on how your actual door interaction is implemented
        TransitionToRightSceneTest(); // Assume this is accessible for testing, or simulate the logic here

        var actualPosition = GameManager.GetPlayerPosition();
        Debug.Log("position after: " + actualPosition[0] + ", " + actualPosition[1]);
        // Assert
        Assert.AreEqual(expectedRow, actualPosition[0], "Row did not match expected value.");
        Assert.AreEqual(expectedColumn, actualPosition[1], "Column did not match expected value.");
    }

    public void TransitionToRightSceneTest()
    {
        int currentPlayerRow = 2;
        int currentPlayerColumn = 2;

        // the index of going left.
        int rightRoomColumn = currentPlayerColumn + 1;

        // check if the left room is valid
        if (rightRoomColumn >= 0 && rightRoomColumn < 5)
        {
            // getting scene name for the left room
            string sceneName = GameManager.MazeHolder.Rooms[currentPlayerRow, rightRoomColumn].SceneName;

            // Load the scene
            if (!string.IsNullOrEmpty(sceneName))
            {
                GameManager.UpdatePlayerPosition(currentPlayerRow, rightRoomColumn);
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log($"String is empty or NULL sceneName content -> {sceneName}");
            }
        }
        
    }
}
