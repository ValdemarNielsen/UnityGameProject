﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Models
{
    public class Enemy
    {
        public Point Pos { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int Attack { get; set; }
        public int HP { get; set; }


        public Enemy (Point startPos, int width = 60, int height = 60, int attack = 5, int hp = 15)
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
