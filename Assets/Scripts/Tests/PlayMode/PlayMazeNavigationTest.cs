using NUnit.Framework;
using UnityEngine;
using GameProject.Models;
using System.Collections.Generic;
using UnityEngine.Assertions;

[TestFixture]
public class PlayerMovementTests
{
    private GameManager _gameManager;
    private Maze _maze;

    [SetUp]
    public void Setup()
    {
        // Initialize the GameManager and Maze before each test
        _gameManager = new GameManager(); // Assuming GameManager can be instantiated like this for the sake of example
        _maze = new Maze(5); // Adjust size according to your needs
        GameManager.MazeHolder = _maze;

        // Set up a simple maze layout for testing, you might need to adjust this based on your Maze and Room implementations
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Room room = new Room();
                room.SceneName = $"Room_{i}_{j}";
                _maze.Rooms[i, j] = room;
            }
        }

        // Initialize the player's starting position
        GameManager.UpdatePlayerPosition(2, 2); // Start in the middle of the maze for this example
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
        _gameManager.TransitionToRightScene(); // Assume this is accessible for testing, or simulate the logic here

        var actualPosition = GameManager.GetPlayerPosition();

        // Assert
        Assert.AreEqual(expectedRow, actualPosition[0], "Row did not match expected value.");
        Assert.AreEqual(expectedColumn, actualPosition[1], "Column did not match expected value.");
    }
}
