using GameProject.Models;
using UnityEngine;

namespace GameProject.Services
{
    public class PlayerMovementService
    {
        private Player player;
        private Bounds gameBounds;

        public PlayerMovementService(Player player, Bounds bounds, int movementSpeed)
        {
            this.player = player;
            this.gameBounds = bounds;
            player.MovementSpeed = movementSpeed; // Fixed assignment of movementSpeed
        }

        public void MoveLeft()
        {
            float movement = player.MovementSpeed * Time.deltaTime; // Adjusted movement calculation
            player.Pos = new Vector2(
                Mathf.Max(player.Pos.x - movement, gameBounds.min.x),
                player.Pos.y
            );
        }

        public void MoveRight()
        {
            float movement = player.MovementSpeed * Time.deltaTime; // Adjusted movement calculation
            player.Pos = new Vector2(
                Mathf.Min(player.Pos.x + movement, gameBounds.max.x - player.Width),
                player.Pos.y
            );
        }

        public void Jump(ref bool isJumping, ref float verticalVelocity, int jumpSpeed)
        {
            if (!isJumping)
            {
                isJumping = true;
                verticalVelocity = -jumpSpeed;
            }
        }

        public void UpdateMovement(ref bool isJumping, ref float verticalVelocity, float gravity)
        {
            float deltaTime = Time.deltaTime; // Cache Time.deltaTime to improve performance
            verticalVelocity += gravity * deltaTime;

            player.Pos = new Vector2(
                player.Pos.x,
                player.Pos.y + verticalVelocity * deltaTime
            );

            if (player.Pos.y <= gameBounds.min.y + player.Height)
            {
                player.Pos = new Vector2(
                    player.Pos.x,
                    gameBounds.min.y + player.Height
                );
                isJumping = false;
                verticalVelocity = 0;
            }
        }
    }
}
