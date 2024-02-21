using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Models
{
    public class Room
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        // Constructor. Ensures all rooms start with no doors (set to false)
        public Room()
        {
            Up = Down = Left = Right = false;

        }

        // Method to count doors, to later assign room number
        public int CountDoors()
        {
            int count = 0;
            if (Up) count++;
            if (Down) count++;
            if (Left) count++;
            if (Right) count++;
            return count;
        }

        // Method to retrieve door configurations as a string
        public string GetDoorConfigurations()
        {
            string configurations = "";
            configurations += Up ? "U" : "";
            configurations += Down ? "D" : "";
            configurations += Left ? "L" : "";
            configurations += Right ? "R" : "";
            return configurations;
        }
    }

}
