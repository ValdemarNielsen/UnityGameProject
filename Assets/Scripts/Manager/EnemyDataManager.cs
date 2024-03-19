using Codice.CM.Client.Differences.Graphic;
using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
    // Static property to access the EnemyData instance
    public static EnemyData EnemyDataInstance
    {
        get
        {
            // Load EnemyData whenever it's accessed
            EnemyData enemyDataInstance = Resources.Load<EnemyData>("EnemyData");
            if (enemyDataInstance == null)
            {
                Debug.LogError("Failed to load EnemyData asset. Make sure it exists in the Resources folder.");
            }
            return enemyDataInstance;
        }
    }

    private void Awake()
    {
        // Load the EnemyData asset when the scene starts (optional)
        EnemyDataInstance.LoadEnemyData();
    }
}
