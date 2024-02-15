using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Services;
using GameProject.Models;

namespace GameProject.Tests
{
    [TestFixture]
    public class GameManagerServiceTests
    {
        [Test]
        public void GetPlayerPos_ReturnInitialPos()
        {
            //Arrange the bounds and expected position
            Rectangle bounds = new Rectangle(0, 0, 800, 600);
            GameManagerService gameManager = new GameManagerService(bounds, 0);
            Point expPos = new Point(bounds.Width / 2, bounds.Height - 50);

            Point ActPos = gameManager.GetPlayerPosition();


            //Assert Whether or not the Actual Position is at the Expected Position
            Assert.That(expPos, Is.EqualTo(ActPos));
        }


        [TestCase(10)]
        [TestCase(1)]
        public void movePlayerLeft_UpdatePlayerPos(int movementSpeed)
        {
            Rectangle bounds = new Rectangle(0, 0, 800, 600);
            GameManagerService gameManager = new GameManagerService(bounds, movementSpeed);
            Point initialPosition = gameManager.GetPlayerPosition();

            Player player = new Player(initialPosition, 60, 100, 10, 100, 10);


            Point expectedPosition = new Point(initialPosition.X - movementSpeed, initialPosition.Y);

            gameManager.MovePlayerLeft();

            Point acPos = gameManager.GetPlayerPosition();


            if (player.MovementSpeed > movementSpeed)
            {
                Assert.That(expectedPosition.X, Is.GreaterThan(acPos.X));
            }
            else if (player.MovementSpeed < movementSpeed)
            {
                Assert.That(expectedPosition.X, Is.LessThan(acPos.X));
            }
            else if (player.MovementSpeed == movementSpeed)
            {
                Assert.That(expectedPosition.X, Is.EqualTo(acPos.X));
            }




        }

        [TestCase(10)]
        [TestCase(1)]
        public void movePlayerRight_UpdatePlayerPos(int movementSpeed)
        {
            Rectangle bounds = new Rectangle(0, 0, 800, 600);
            GameManagerService gameManager = new GameManagerService(bounds, movementSpeed);
            Point initialPosition = gameManager.GetPlayerPosition();

            Player player = new Player(initialPosition, 60, 100, 10, 100, 10);


            Point expectedPosition = new Point(initialPosition.X + movementSpeed, initialPosition.Y);

            gameManager.MovePlayerRight();

            Point acPos = gameManager.GetPlayerPosition();


            if (player.MovementSpeed > movementSpeed)
            {
                Assert.That(expectedPosition.X, Is.LessThan(acPos.X));
            }
            else if (player.MovementSpeed < movementSpeed)
            {
                Assert.That(expectedPosition.X, Is.GreaterThan(acPos.X));
            }
            else if (player.MovementSpeed == movementSpeed)
            {
                Assert.That(expectedPosition.X, Is.EqualTo(acPos.X));
            }

        }




    }
}
