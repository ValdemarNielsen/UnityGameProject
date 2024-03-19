using NUnit.Framework;
using UnityEngine;
using GameProject.Models;
using System.Collections.Generic;
using UnityEngine.Assertions;
using Assert = NUnit.Framework.Assert;
using GameProject.Services;
using UnityEngine.SceneManagement;



[TestFixture]
public class PlayerMazeNavigationTest
{
    private Maze _maze;

    [SetUp]
    public void Setup()
    {
        int mazeSize = 5; // or any other size you need for testing
        MazeGeneratorService mazeGeneratorService = new MazeGeneratorService(mazeSize);
        Maze maze = mazeGeneratorService.GenerateMaze();
        

        // Since GameManager is static, we directly set its static properties
        GameManager.MazeHolder = maze;
        GameManager.UpdatePlayerPosition(mazeSize / 2, mazeSize / 2); // Initialize player's position

    }

    [Test]
    public void PlayerMovesRight_UpdatesPositionCorrectly()
    {
        // Arrange
        var expectedRow = 2;
        var expectedColumn = 3; // Expecting to move to the right

        // Act
        // Simulate the right door transition
        // This part might need adjustment based on how your actual door interaction is implemented
        TransitionToRightSceneTest(); // Assume this is accessible for testing, or simulate the logic here

        var actualPosition = GameManager.GetPlayerPosition();

        // Assert
        Assert.AreEqual(expectedRow, actualPosition[0], "Row did not match expected value.");
        Assert.AreEqual(expectedColumn, actualPosition[1], "Column did not match expected value.");
    }

    public void TransitionToRightSceneTest()
    {
        Debug.Log("First part of transition");
        int currentPlayerRow = 2;
        int currentPlayerColumn = 2;

        // the index of going left.
        int rightRoomColumn = currentPlayerColumn + 1;

        // check if the left room is valid
        if (rightRoomColumn >= 0 && rightRoomColumn < 5)
        {
            Debug.Log("First IF - statement of transition");
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
