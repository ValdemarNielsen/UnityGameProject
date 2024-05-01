using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int spawnRate;


    void Start()
    {

        int[] playerPosition = GameManager.GetPlayerPosition();

        if (GetRandomPercentage() < spawnRate || GameManager.hasKilled[playerPosition[0], playerPosition[1]] == 1)
        {
            foreach (var enemy in enemies) { 
            Destroy(enemy);
            }
        }
    }

    private int GetRandomPercentage()
    {
        return Random.Range(0, 100);
    }
}



