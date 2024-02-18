using GameProject.Models;
using UnityEngine;

public class ChestButtonHandler : MonoBehaviour
{
    // The distance at which the player can interact with the chest.
    public float interactionDistance = 3f;

    // Reference to the player GameObject. You can assign this in the Unity Editor.
    public Player player;

    // Reference to the chest's Animator component.
    public Animator chestAnimator; // Assign this in the Unity Editor.

    // Update is called once per frame
    void Update()
    {
        // Check if the player is close enough to the chest and presses the "E" key.
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerCloseEnough())
        {
            // Call the method to handle the interaction with the chest.
            InteractWithChest();
        }
    }
        
    // Method to check if the player is close enough to the chest.
    bool IsPlayerCloseEnough()
    {
        // Calculate the distance between the player and the chest.
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Return true if the distance is less than or equal to the interaction distance.
        return distance <= interactionDistance;
    }

    // Method to handle the interaction with the chest.
    void InteractWithChest()
    {
        // Check if the Animator component is attached.
        if (chestAnimator != null)
        {
            // Trigger the chest opening animation.
            chestAnimator.SetTrigger("OpenChest"); // "OpenChest" has to be same as Trigger name if changed. 
        }
        else
        {
            Debug.LogError("Animator not assigned on ChestButtonHandler.");
        }
    }
}
