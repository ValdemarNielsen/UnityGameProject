using GameProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Services
{
    public class GameManagerService
    {
        // Properties
        private Player player;

        private PlayerMovementService playerMovement;
        private Rectangle gameBounds;

        // Constructor
        public GameManagerService(Rectangle bounds, int movementSpeed)
        {
            gameBounds = bounds;
            player = new Player(new Point(bounds.Width / 2, bounds.Height - 50), movementSpeed);
            playerMovement = new PlayerMovementService(player, bounds, movementSpeed);
        }

        // Method to get the player's position
        public Point GetPlayerPosition()
        {
            return player.GetPosition();
        }

        // Method to move the player left
        public void MovePlayerLeft()
        {
            playerMovement.MoveLeft();
        }

        // Method to move the player right
        public void MovePlayerRight()
        {
            playerMovement.MoveRight();
        }

        // Method to handle player jumping
        public void PlayerJump(ref bool isJumping, ref float verticalVelocity, int jumpSpeed, int maxJumpHeight)
        {
            playerMovement.Jump(ref isJumping, ref verticalVelocity, jumpSpeed);
        }

        // Method to update the game state
        public void UpdateGame(ref bool isJumping, ref float verticalVelocity, float gravity)
        {
            playerMovement.UpdateMovement(ref isJumping, ref verticalVelocity, gravity);
        }
    }
}
