using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemyIDManager : MonoBehaviour
{
    // Singleton instance
    public static EnemyIDManager Instance;

    // Dictionary to store unique identifiers for enemies
    private Dictionary<GameObject, string> enemyIDs = new Dictionary<GameObject, string>();

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance of EnemyIDManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Generate a unique identifier for the enemy
    public string GenerateUniqueIdentifier(GameObject enemy)
    {
        string uniqueIdentifier = Guid.NewGuid().ToString();
        enemyIDs.Add(enemy, uniqueIdentifier);
        return uniqueIdentifier;
    }

    // Get the unique identifier of an enemy
    public string GetUniqueIdentifier(GameObject enemy)
    {
        string uniqueIdentifier;
        if (enemyIDs.TryGetValue(enemy, out uniqueIdentifier))
        {
            return uniqueIdentifier;
        }
        else
        {
            return GenerateUniqueIdentifier(enemy);
        }
    }

    // Remove the unique identifier of an enemy (e.g., when it's destroyed)
    public void RemoveUniqueIdentifier(GameObject enemy)
    {
        enemyIDs.Remove(enemy);
    }
}
