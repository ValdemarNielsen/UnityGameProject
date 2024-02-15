using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Models;


namespace GameProject.Services
{
    public class PlayerMovementService
    {
        private Player player;
        private Rectangle gameBounds;
        public PlayerMovementService(Player player, Rectangle bounds, int movementSpeed)
        {
            this.player = player;
            this.gameBounds = bounds;
            movementSpeed = player.MovementSpeed;
        }

        public void MoveLeft()
        {
            player.Pos = new Point(Math.Max(player.Pos.X - player.MovementSpeed, gameBounds.Left), player.Pos.Y);
        }

        public void MoveRight()
        {
            player.Pos = new Point(Math.Min(player.Pos.X + player.MovementSpeed, gameBounds.Right - player.Width), player.Pos.Y);
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
            verticalVelocity += gravity;

            player.Pos = new Point(player.Pos.X, (int)(player.Pos.Y + verticalVelocity));

            if (player.Pos.Y >= gameBounds.Bottom - player.Height)
            {
                player.Pos = new Point(player.Pos.X, gameBounds.Bottom - player.Height);
                isJumping = false;
                verticalVelocity = 0;
            }
        }
    }
}
