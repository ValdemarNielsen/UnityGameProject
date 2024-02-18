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
            movementSpeed = player.MovementSpeed;
        }

        public void MoveLeft()
        {
            player.Pos = new Vector2(
                Mathf.Max(player.Pos.x - player.MovementSpeed * Time.deltaTime, gameBounds.min.x),
                player.Pos.y
            );
        }

        public void MoveRight()
        {
            player.Pos = new Vector2(
                Mathf.Min(player.Pos.x + player.MovementSpeed * Time.deltaTime, gameBounds.max.x - player.Width),
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
            verticalVelocity += gravity * Time.deltaTime;

            player.Pos = new Vector2(
                player.Pos.x,
                player.Pos.y + verticalVelocity * Time.deltaTime
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
