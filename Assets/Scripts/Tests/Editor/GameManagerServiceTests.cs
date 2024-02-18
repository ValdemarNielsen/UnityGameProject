using GameProject.Models;
using GameProject.Services;
using NUnit.Framework;
using UnityEngine;

namespace GameProject.Tests
{
    [TestFixture]
    public class GameManagerServiceTests
    {
        [Test]
        public void GetPlayerPos_ReturnInitialPos()
        {
            // Arrange the bounds and expected position
            Vector2 boundsCenter = new Vector2(800, 600);
            Vector2 boundsSize = Vector2.zero;
            GameManagerService gameManager = new GameManagerService(new Bounds(boundsCenter, boundsSize), 0);
            Vector2 expPos = new Vector2(boundsCenter.x, boundsCenter.y - 50); // Adjusted expected position to Vector2

            Vector2 actPos = gameManager.GetPlayerPosition(); // Changed Point to Vector2 for actual position

            // Assert Whether or not the Actual Position is at the Expected Position
            Assert.That(expPos, Is.EqualTo(actPos));
        }

        [TestCase(10)]
        [TestCase(1)]
        public void movePlayerLeft_UpdatePlayerPos(int movementSpeed)
        {
            Vector2 boundsCenter = Vector2.zero;
            Vector2 boundsSize = new Vector2(800, 600);
            GameManagerService gameManager = new GameManagerService(new Bounds(boundsCenter, boundsSize), movementSpeed);
            Vector2 initialPosition = gameManager.GetPlayerPosition(); // Changed Point to Vector2 for initial position

            Player player = new Player(initialPosition, 60, 100, 10, 100, 10); // Adjusted Player initialization to use Vector2

            Vector2 expectedPosition = new Vector2(initialPosition.x - movementSpeed, initialPosition.y); // Adjusted expected position to Vector2

            gameManager.MovePlayerLeft();

            Vector2 acPos = gameManager.GetPlayerPosition(); // Changed Point to Vector2 for actual position

            // Assert
            Assert.That(expectedPosition.x, Is.EqualTo(acPos.x));
        }

        [TestCase(10)]
        [TestCase(1)]
        public void movePlayerRight_UpdatePlayerPos(int movementSpeed)
        {
            Vector2 boundsCenter = Vector2.zero;
            Vector2 boundsSize = new Vector2(800, 600);
            GameManagerService gameManager = new GameManagerService(new Bounds(boundsCenter, boundsSize), movementSpeed);
            Vector2 initialPosition = gameManager.GetPlayerPosition(); // Changed Point to Vector2 for initial position

            Player player = new Player(initialPosition, 60, 100, 10, 100, 10); // Adjusted Player initialization to use Vector2

            Vector2 expectedPosition = new Vector2(initialPosition.x + movementSpeed, initialPosition.y); // Adjusted expected position to Vector2

            gameManager.MovePlayerRight();

            Vector2 acPos = gameManager.GetPlayerPosition(); // Changed Point to Vector2 for actual position

            // Assert
            Assert.That(expectedPosition.x, Is.EqualTo(acPos.x));
        }
    }
}
