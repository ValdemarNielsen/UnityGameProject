using System.Drawing;

namespace GameProject.Models
{
    public class Boss
    {
        public Point Pos { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int Attack { get; set; }
        public int HP { get; set; }


        public Boss(Point startPos, int width = 60, int height = 60, int attack = 15, int hp = 50)
        {
            Pos = startPos;
            Width = width;
            Height = height;
            Attack = attack;
            HP = hp;
        }
        public Point GetPosition()
        {
            return Pos;
        }
    }
}
