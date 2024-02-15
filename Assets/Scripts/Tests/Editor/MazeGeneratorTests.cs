using GameProject.Models;
using GameProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using UnityEngine;


namespace GameProject.Tests
{
    [TestFixture]
    public class MazeGeneratorTests
    {
        public static class MazePrinter
        {
            public static void PrintMaze(Maze maze)
            {
                /// TestContext.Out.WriteLine("Some debug information");
                int size = maze.Rooms.GetLength(0); // Assuming a square maze
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Debug.Log(maze.Rooms[i, j].CountDoors() + " ");
                    }
                    Debug.Log("");
                }
            }
        }

        [Test]
        public void GenerateAndPrintMaze_ShouldSucceed()
        {
            /// TestContext.Out.WriteLine("Some debug information");
            var generator = new MazeGeneratorService(5); // 5x5 maze
            var maze = generator.GenerateMaze();
            MazePrinter.PrintMaze(maze);
            //  Make  if() statement so if any room is 0> or >4, corner room is 0> or >2, edgeroom 0> or >3 it fails. 
            int size = maze.Rooms.GetLength(0); // Assuming a square maze

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int doorCount = maze.Rooms[i, j].CountDoors();

                    // Check for corner rooms
                    if ((i == 0 || i == size - 1) && (j == 0 || j == size - 1))
                    {
                        Assert.That(doorCount, Is.GreaterThan(0).And.LessThanOrEqualTo(2), $"Corner room at ({i}, {j}) has an invalid number of doors: {doorCount}");
                    }
                    // Check for edge rooms but not corners
                    else if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                    {
                        Assert.That(doorCount, Is.GreaterThan(0).And.LessThanOrEqualTo(3), $"Edge room at ({i}, {j}) has an invalid number of doors: {doorCount}");
                    }
                    // Check for interior rooms
                    else
                    {
                        Assert.That(doorCount, Is.GreaterThan(0).And.LessThanOrEqualTo(4), $"Interior room at ({i}, {j}) has an invalid number of doors: {doorCount}");
                    }
                }
            }
        }

        [Test]
        public void GenerateAndPrintMazeWithUDLR_ShouldSucceed()
        {
            var generator = new MazeGeneratorService(5); // 5x5 maze for example (agreed upon size for game-map)
            var maze = generator.GenerateMaze();
            PrintMazeWithUDLR(maze); // Call the modified PrintMaze method
        }

        // This method is specifically designed for the UDLR visualization
        private void PrintMazeWithUDLR(Maze maze)
        {
            int size = maze.Rooms.GetLength(0); // Assuming a square maze
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Room room = maze.Rooms[i, j];
                    string doors = "";
                    doors += room.Up ? "U" : "";
                    doors += room.Down ? "D" : "";
                    doors += room.Left ? "L" : "";
                    doors += room.Right ? "R" : "";

                    // Padding the string for visual alignment
                    Debug.Log(doors.PadRight(4, ' ') + " ");
                }
                Debug.Log("");
            }
        }
    }
}