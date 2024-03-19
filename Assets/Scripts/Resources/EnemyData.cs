using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Custom/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [System.Serializable]
    public class EnemyState
    {
        public string enemyID;
        public bool isKilled;
        public int roomRow; // Row index of the room where the enemy was located
        public int roomCol; // Column index of the room where the enemy was located
        public Vector2 positionInRoom; // Position of the enemy within the room
    }

    public List<EnemyState> enemyStates = new List<EnemyState>();
    private int idCounter = 0;

    private static EnemyData instance; // Singleton instance

    public static EnemyData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<EnemyData>("EnemyData"); // Load the EnemyData asset
                DontDestroyOnLoad(instance); // Don't destroy the EnemyData asset when loading a new scene
            }
            return instance;
        }
    }

    public string GenerateUniqueID()
    {
        string uniqueID = "Enemy_" + idCounter;
        idCounter++;
        return uniqueID;
    }

    public bool IsEnemyKilled(string enemyID, int roomRow, int roomCol, Vector2 positionInRoom)
    {
        foreach (var enemyState in enemyStates)
        {
            // Check if the enemy's ID, room position, and position within the room match
            if (enemyState.enemyID == enemyID &&
                enemyState.roomRow == roomRow &&
                enemyState.roomCol == roomCol &&
                enemyState.positionInRoom == positionInRoom)
            {
                return enemyState.isKilled;
            }
        }
        return false; // Default to false if enemyID not found or position doesn't match
    }

    public void MarkAsKilled(string enemyID, int roomRow, int roomCol, Vector2 positionInRoom)
    {
        for (int i = 0; i < enemyStates.Count; i++)
        {
            if (enemyStates[i].enemyID == enemyID &&
                enemyStates[i].roomRow == roomRow &&
                enemyStates[i].roomCol == roomCol &&
                enemyStates[i].positionInRoom == positionInRoom)
            {
                enemyStates[i].isKilled = true;
                SaveEnemyData(); // Save enemy data after marking as killed
                return; // Exit loop once enemy is found and marked as killed
            }
        }
    }

    public void SaveEnemyData()
    {
        // Convert enemyStates list to binary format
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/enemyData.dat";
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(fileStream, enemyStates);
        }
    }

    public void LoadEnemyData()
    {
        string filePath = Application.persistentDataPath + "/enemyData.dat";
        if (File.Exists(filePath))
        {
            // Load enemy data from file
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                enemyStates = (List<EnemyState>)formatter.Deserialize(fileStream);
            }
        }
    }
}
