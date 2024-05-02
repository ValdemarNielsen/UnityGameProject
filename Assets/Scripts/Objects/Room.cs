namespace GameProject.Models
{
    public class Room
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public string DirectionLetter { get; set; }
        public string SceneName { get; set; } // Add SceneName property

        // Constructor. Ensures all rooms start with no doors (set to false)
        public Room()
        {
            Up = Down = Left = Right = false;
            DirectionLetter = "";
            SceneName = ""; // Initialize SceneName
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
