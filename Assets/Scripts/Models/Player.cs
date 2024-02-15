using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Models
{
    public class Player
    {
        public Point Pos { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int Attack { get; set; }
        public int HP { get; set; }
        public int MovementSpeed {  get; set; }


        public Player(Point startingPos, int width = 60, int height = 100, int attack = 10, int hp = 100, int movementSpeed = 10)
        {
            Pos = startingPos;
            Width = width;
            Height = height;
            Attack = attack;
            HP = hp;
            MovementSpeed = movementSpeed;
        }

        public Point GetPosition()
        {
            return Pos;
        }
    }
}
