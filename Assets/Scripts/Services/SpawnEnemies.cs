using UnityEngine;

namespace GameProject.Models
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] enemyPrefabs; // Array of enemy prefabs
        public int maxEnemies = 4; // Maximum number of enemies to spawn

        void Start()
        {
            SpawnEnemies();
        }

        void SpawnEnemies()
        {
            // Calculate a random number of enemies to spawn
            int numEnemies = Random.Range(0, maxEnemies);

            // Spawn enemies
            for (int i = 0; i < numEnemies; i++)
            {
                // Get a random enemy prefab from the array
                GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                // Spawn the enemy prefab at a random position within the scene
                Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)); // Adjust the range as needed
                GameObject enemyGO = Instantiate(randomPrefab, randomPosition, Quaternion.identity);

                // Access the Enemy component of the spawned GameObject
                Enemy enemy = enemyGO.GetComponent<Enemy>();
                Debug.Log("I SPAWNED A MOB");
                Debug.Log(enemyGO.gameObject.name);

            }
        }
    }
}
