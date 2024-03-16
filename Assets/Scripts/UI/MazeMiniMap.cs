﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Assets.Scripts.UI
{


    // Logic for doors to update glow:                 GameManager.MiniMapGlow[DownRoomRow, currentPlayerColumn] = true;
    // logic for GameManager to hold instance of minimap :     public static bool[,] MiniMapGlow { get; set; }

    public class MazeMiniMap : MonoBehaviour
    {
        [SerializeField] GameObject gridPrefab;
        [SerializeField] GameObject gridPrefabGlow;

        // Adjust the tile size and gap as needed (Tilesize might now work correctly, but can be adjusted manually from unity by changeing the red+visited square)
        float tileSize = 0.1f;
        float gapSize = 0.29f;

        private void Update()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // Calculate position with gap
                    float xPosition = 7 + j * (tileSize + gapSize); // Use j for x-coordinate (columns)
                    float yPosition = 4 - i * (tileSize + gapSize); // Use i for y-coordinate (rows)

                    if (i == GameManager.playerRowHolder && j == GameManager.playerColHolder) // Corrected comparison
                    {
                        GameObject grids = Instantiate(gridPrefabGlow) as GameObject;
                        grids.transform.position = new Vector3(xPosition, yPosition, 0f);
                    }
                    else
                    {
                        GameObject grid = Instantiate(gridPrefab) as GameObject;
                        grid.transform.position = new Vector3(xPosition, yPosition, 0f);
                    }
                }
            }
        }



    }
}