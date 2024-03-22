using GameProject.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{

    private int[] currentPlayerPosition = GameManager.GetPlayerPosition();

    private int enemyDeadCount;

    private int totalEnemies;

    private void Start()
    {
        void Start()
        {
            // Initialize the total number of enemies in the scene
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Blue_Slime");
            totalEnemies = enemies.Length;
        }
    }
    private void Update()
    {
        CheckAllEnemiesDestroyed();
    }
    private void CheckAllEnemiesDestroyed()
    {
        // Find all GameObjects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Blue_Slime");

        // Calculate the number of remaining enemies in the scene
        int remainingEnemies = enemies.Count(enemy => enemy != null);

        // If the number of remaining enemies is zero, all enemies have been destroyed
        bool allDestroyed = remainingEnemies == 0;

        if (allDestroyed)
        {
            GameManager.hasKilled[currentPlayerPosition[0],currentPlayerPosition[1]] = 1;
        }
    }

}
