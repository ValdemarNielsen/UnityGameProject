using GameProject.Models;
using UnityEngine;

public class ChestButtonHandler : MonoBehaviour
{
    // The distance at which the player can interact with the chest.
    public float interactionDistance = 1.2f;

    // Reference to the player GameObject. You can assign this in the Unity Editor.
    public Player player;

    // Reference to the chest's Animator component.
    public Animator chestAnimator; // Assign this in the Unity Editor.

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Find the Player component in the scene and assign it.
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player component not found in the scene.");
        }

        // Ensure the Animator component is assigned.
        chestAnimator = GetComponent<Animator>();
        if (chestAnimator == null)
        {
            Debug.LogError("Chest Animator component not found in the inspector.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere in the Scene view showing the interaction distance
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || chestAnimator == null)
        {
            // If there is no player or no animator, don't proceed with the update loop.
            return;
        }

        // Check if the player is close enough to the chest and presses the "E" key.
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool closeEnough = IsPlayerCloseEnough();

            if (closeEnough)
            {
                // Call the method to handle the interaction with the chest.
                InteractWithChest();
            }
        }
    }

    // Method to check if the player is close enough to the chest.
    bool IsPlayerCloseEnough()
    {
        // Calculate the distance between the player and the chest.
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log($"Chest position: {transform.position}, Player position: {player.transform.position}, Distance: {distance}, max distance 1.2f");

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
