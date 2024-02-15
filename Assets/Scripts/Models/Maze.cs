using GameProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Models
{
    public class Maze
    {
        public Room[,] Rooms { get; private set; }

        public Maze(int size)
        {
            Rooms = new Room[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Rooms[i, j] = new Room();
                }
            }   
        }
    }
}
