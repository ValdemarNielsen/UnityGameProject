using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int spawnRate;


    void Start()
    {

        int[] playerPosition = GameManager.GetPlayerPosition();

        if (GetRandomPercentage() < spawnRate && !GameManager.HasVisited(playerPosition[0], playerPosition[1]))
        {
            Destroy(enemy);
        }
    }

    private int GetRandomPercentage()
    {
        return Random.Range(0, 100);
    }
}



