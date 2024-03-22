using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int spawnRate;


    void Start()
    {

        int[] playerPosition = GameManager.GetPlayerPosition();

        if (GetRandomPercentage() < spawnRate)
        {
            Destroy(enemy);
        }
    }

    private int GetRandomPercentage()
    {
        return Random.Range(0, 100);
    }
}



