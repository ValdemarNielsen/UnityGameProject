using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProject.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using SceneManagement;


/// MazeGeneratorService.cs: Contains the logic for generating the entire maze. This service would use algorithms to ensure 
/// all rooms are accessible from the starting point and correctly interconnected. It may utilize RoomGeneratorService to create 
/// individual rooms with specific configurations.
namespace GameProject.Services
{
    public class MazeGeneratorService
    {
        private static Maze maze;
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
            UnityEngine.Debug.Log("MazeGenerator is called again");
            int startX = size / 2;
            int startY = size / 2;
            DFS(startX, startY);
            // sceneManagement.AssignScenesToRooms(maze); // Assign scenes after maze generation
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
                // If so, it won't go there / open a door.
                if (newX >= 0 && newX < size && newY >= 0 && newY < size)
                {
                    // checks if it's not visited or gives an 18% chance to go continue anyways.
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
            Room currentRoom = maze.Rooms[x, y];
            Room nextRoom = maze.Rooms[x + dx, y + dy];

            // Add direction letters based on the relative positions of rooms
            if (dx == -1)
            {
                currentRoom.Up = true;
                nextRoom.Down = true;
                AddDirectionLetter(currentRoom, 'U');
                AddDirectionLetter(nextRoom, 'D');
            }
            else if (dx == 1)
            {
                currentRoom.Down = true;
                nextRoom.Up = true;
                AddDirectionLetter(currentRoom, 'D');
                AddDirectionLetter(nextRoom, 'U');
            }

            if (dy == -1)
            {
                currentRoom.Left = true;
                nextRoom.Right = true;
                AddDirectionLetter(currentRoom, 'L');
                AddDirectionLetter(nextRoom, 'R');
            }
            else if (dy == 1)
            {
                currentRoom.Right = true;
                nextRoom.Left = true;
                AddDirectionLetter(currentRoom, 'R');
                AddDirectionLetter(nextRoom, 'L');
            }
        }


        private void AddDirectionLetter(Room room, char directionLetter)
        {
            // Create a dictionary to map the direction letters to their correct order
            Dictionary<char, int> orderMap = new Dictionary<char, int>
            {
                { 'U', 0 },
                { 'R', 1 },
                { 'D', 2 },
                { 'L', 3 }
            };

            // If the letter is not already in the room's direction letters
            if (!room.DirectionLetter.Contains(directionLetter))
            {
                // Get the index to insert the new direction letter
                int index = 0;
                foreach (char direction in room.DirectionLetter)
                {
                    if (orderMap[direction] > orderMap[directionLetter])
                    {
                        break;
                    }
                    index++;
                }
                // Insert the new direction letter at the determined index
                room.DirectionLetter = room.DirectionLetter.Insert(index, directionLetter.ToString());
            }
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
