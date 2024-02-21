using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProject.Models;
using System.Threading.Tasks;

/// MazeGeneratorService.cs: Contains the logic for generating the entire maze. This service would use algorithms to ensure 
/// all rooms are accessible from the starting point and correctly interconnected. It may utilize RoomGeneratorService to create 
/// individual rooms with specific configurations.
namespace GameProject.Services
{
    public class MazeGeneratorService
    {
        private Maze maze;
        private int size;
        private bool[,] visited;
        private Random random = new Random();

        
        public MazeGeneratorService(int size)
        {
            this.size = size;
            maze = new Maze(size);
            visited = new bool[size, size];
        }

        public Maze GenerateMaze()
        {
            // Start from the middle room
            int startX = size / 2;
            int startY = size / 2;
            DFS(startX, startY);
            return maze;
        }

        private void DFS(int x, int y)
        {
            visited[x, y] = true;

            // Directions: Up, Right, Down, Left
            var directions = new (int, int)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };
            // Shuffle directions to ensure randomness
            directions = directions.OrderBy(d => random.Next()).ToArray();

            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx, newY = y + dy;

                // Check bounds and if already visited
                // If so, it wornt go there / open a door.
                if (newX >= 0 && newX < size && newY >= 0 && newY < size)
                {
                    // checks if its not visited or gives a 18% chance to go continue anyways.
                    if (!visited[newX, newY] || random.NextDouble() < 0.18)
                    {
                        // Connect current room with the new room
                        ConnectRooms(x, y, dx, dy);
                        DFS(newX, newY);
                    }
                }
                
            }
        }

        private void ConnectRooms(int x, int y, int dx, int dy)
        {
            if (dx == -1) { maze.Rooms[x, y].Up = true; maze.Rooms[x - 1, y].Down = true; }
            else if (dx == 1) { maze.Rooms[x, y].Down = true; maze.Rooms[x + 1, y].Up = true; }
            if (dy == -1) { maze.Rooms[x, y].Left = true; maze.Rooms[x, y - 1].Right = true; }
            else if (dy == 1) { maze.Rooms[x, y].Right = true; maze.Rooms[x, y + 1].Left = true; }
        }

        private bool ShouldConnectVisitedRoom(int x, int y, int newX, int newY)
        {
            // Implement logic to determine if an additional connection should be made
            // This could be based on the number of existing doors in the room, 
            // ensuring that not every room becomes too interconnected.
            return true; // Simplified for illustration
        }

    }

}
