using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnRate;
    [SerializeField] private bool rememberKilledEnemies = true;

    private string enemyID; // Unique identifier for the enemy

    private void Awake()
    {
        // Generate unique ID for the enemy
        enemyID = EnemyData.Instance.GenerateUniqueID();

        // Check if the enemy is killed and destroy if necessary
        if (rememberKilledEnemies && EnemyData.Instance.IsEnemyKilled(enemyID))
        {
            Destroy(gameObject); // Destroy the EnemySpawn GameObject if the enemy is killed
        }
        else if (!EnemyData.Instance.IsEnemyKilled(enemyID) && GetRandomPercentage() < spawnRate)
        {
            SpawnEnemy(); // Spawn the enemy if it's not killed
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    private int GetRandomPercentage()
    {
        return Random.Range(0, 100);
    }

    // Call this method when the enemy is killed
    public void MarkAsKilled()
    {
        if (rememberKilledEnemies)
        {
            EnemyData.Instance.MarkAsKilled(enemyID); // Mark the enemy as killed in the enemy data
            EnemyData.Instance.SaveEnemyData();
        }
    }
}
