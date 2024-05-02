using UnityEngine;
using GameProject.Models;
using System.Collections.Generic;

namespace SceneManagement
{
    public static class SceneManagements
    {
        // List of our scenes
        private static string[] scenes = { "D", "DL", "L", "R", "RD", "RDL", "RL", "U", "UD", "UDL", "UL", "UR", "URD", "URDL", "URL" }; // Add all our scenes

        // Dictionary to map room layouts to scenes
        private static Dictionary<string, string> layoutToSceneMap = new Dictionary<string, string>();

        // Method to initialize the layout to scene mapping
        private static void InitializeLayoutToSceneMap()
        {
            // Add mappings based on room layouts and scenes. Its "RoomLetters", "Unity Scene name" . 
            layoutToSceneMap.Add("D", "D");
            layoutToSceneMap.Add("DL", "DL");
            layoutToSceneMap.Add("L", "L");
            layoutToSceneMap.Add("R", "R");
            layoutToSceneMap.Add("RD", "RD");
            layoutToSceneMap.Add("RDL", "RDL");
            layoutToSceneMap.Add("RL", "RL");
            layoutToSceneMap.Add("U", "U");
            layoutToSceneMap.Add("UD", "UD");
            layoutToSceneMap.Add("UDL", "UDL");
            layoutToSceneMap.Add("UL", "UL");
            layoutToSceneMap.Add("UR", "UR");
            layoutToSceneMap.Add("URD", "URD");
            layoutToSceneMap.Add("URDL", "URDL");
            layoutToSceneMap.Add("URL", "URL");
            // Add all our mappings
        }

        // Method to assign scenes to rooms in the maze based on their layout
        public static void AssignScenesToRooms(Maze maze)
        {
            InitializeLayoutToSceneMap();

            int size = maze.Rooms.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Room room = maze.Rooms[i, j];
                    string layout = room.DirectionLetter;
                    string sceneName = GetSceneForLayout(layout);
                    room.SceneName = sceneName;
                }
            }
        }

        // Method to get the scene associated with a given room layout
        private static string GetSceneForLayout(string layout)
        {
            // Check if the layout exists in the mapping
            if (layoutToSceneMap.ContainsKey(layout))
            {
                return layoutToSceneMap[layout];
            }
            else
            {
                // If the layout does not exist, assign a random scene. This should not happen.
                int randomIndex = Random.Range(0, scenes.Length);
                return scenes[randomIndex];
            }
        }
    }

}