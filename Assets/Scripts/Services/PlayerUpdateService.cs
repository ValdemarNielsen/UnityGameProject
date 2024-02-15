using GameProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Services
{
    public class PlayerUpdateService
    {
        // Method to update player HP
        public static void UpdateHP(Player player, int deltaHP)
        {
            player.HP += deltaHP;
            if (player.HP < 0)
            {
                player.HP = 0;
            } 
        }

        // Method to update player attack stat
        public static void UpdateAttack(Player player, int deltaAttack)
        {
            player.Attack += deltaAttack;
        }

        // Method to update the player movement speed
        public static void UpdateMovementSpeed(Player player, int deltaMovementSpeed)
        {
            player.MovementSpeed += deltaMovementSpeed;
        }

    }
}
