using GameProject.Models;
using SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpDoor : MonoBehaviour
{
    public MazeManager mazeManager = new MazeManager();
    // The distance at which the player can interact with the chest.
    public float interactionDistance = 1.5f;

    // Reference to the player GameObject. You can assign this in the Unity Editor.
    public Player player;
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool closeEnough = IsPlayerCloseEnough();
            Debug.Log($"E key pressed. Is player close enough? {closeEnough}");

            if (closeEnough)
            {
                // Call the method to handle the interaction with the door;
                TransitionToUpScene();
            }
            else
            {
                Debug.Log("Not close enough to door");
            }

        }
    }

    public void TransitionToUpScene()
    {
        Debug.Log("First part of transition");
        int[] currentPlayerPosition = mazeManager.GetPlayerPosition();
        int currentPlayerRow = currentPlayerPosition[0];
        int currentPlayerColumn = currentPlayerPosition[1];

        // the index of going left.
        int UpRoomRow = currentPlayerRow - 1;

        // check if the left room is valid
        if (UpRoomRow >= 0 && UpRoomRow < mazeManager.mazeSize)
        {
            Debug.Log("First IF - statement of transition");
            // getting scene name for the left room
            string sceneName = GameManager.MazeHolder.Rooms[UpRoomRow, currentPlayerColumn].SceneName;

            // Load the scene
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
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
        Debug.Log($"Chest position: {transform.position}, Player position: {player.transform.position}, Distance: {distance}");

        // Return true if the distance is less than or equal to the interaction distance.
        return distance <= interactionDistance;
    } */
}