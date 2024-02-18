using GameProject.Models;
using UnityEngine;

namespace GameProject.Services
{
    public class GameManagerService
    {
        // Properties
        private Player player;
        private PlayerMovementService playerMovement;
        private Bounds gameBounds;

        // Constructor
        public GameManagerService(Bounds bounds, int movementSpeed)
        {
            gameBounds = bounds;
            // Adjusted the initial position of the player to ensure it stays within the bounds
            player = new Player(new Vector2(bounds.center.x, bounds.center.y), 60, 100, 10, 100, movementSpeed);
            playerMovement = new PlayerMovementService(player, bounds, movementSpeed);
        }

        // Method to get the player's position
        public Vector2 GetPlayerPosition()
        {
            return player.Pos;
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
