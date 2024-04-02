using GameProject.Models;
using SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightDoor : MonoBehaviour
{
    public MazeManager mazeManager = new MazeManager();
    // The distance at which the player can interact with the chest.
    public float interactionDistance = 1.5f;

    // Reference to the player GameObject. You can assign this in the Unity Editor.
    public Player player;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool closeEnough = IsPlayerCloseEnough();
          //  Debug.Log($"E key pressed. Is player close enough to the RIGHT door? {closeEnough}");

            if (closeEnough)
            {
                // Call the method to handle the interaction with the door;
                TransitionToRightScene();
            }
            else
            {
                Debug.Log("Not close enough to RIGHT DOOR");
            }

        }
    }

    public void TransitionToRightScene()
    {
        int[] currentPlayerPosition = GameManager.GetPlayerPosition();
        int currentPlayerRow = currentPlayerPosition[0];
        int currentPlayerColumn = currentPlayerPosition[1];

        // the index of going left.
        int rightRoomColumn = currentPlayerColumn + 1;

        // check if the left room is valid
        if (rightRoomColumn >= 0 && rightRoomColumn < 5)
        {
            // getting scene name for the left room
            string sceneName = GameManager.MazeHolder.Rooms[currentPlayerRow, rightRoomColumn].SceneName;

            // Load the scene
            if (!string.IsNullOrEmpty(sceneName))
            {
                

                // Set the spawn point to the new position
                GameManager.spawnPoint = new Vector2(-8f, -2.8f);
                GameManager.UpdatePlayerPosition(currentPlayerRow, rightRoomColumn);
                SceneManager.LoadScene(sceneName);
               // GameManager.MiniMapGlow[rightRoomColumn, currentPlayerColumn] = true;
            }
            else
            {
                Debug.Log($"String is empty or NULL sceneName content -> {sceneName}");
            }
        }
    }

    // Method to check if the player is close enough to the chest.
    bool IsPlayerCloseEnough()
    {
        // Calculate the distance between the player and the chest.
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Return true if the distance is less than or equal to the interaction distance.
        return distance <= interactionDistance;
    } 
}
