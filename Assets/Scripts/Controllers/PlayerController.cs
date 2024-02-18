using UnityEngine;
using GameProject.Models; // Import the namespace where Player class is defined
using GameProject.Services; // Import the namespace where Player class is defined


public class PlayerController : MonoBehaviour
{
    // Reference to the Player component attached to the player GameObject.
    public Player player;

    // Speed at which the player moves.
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Handle player input for movement
        HandleMovementInput();
    }

    // Method to handle player movement input
    void HandleMovementInput()
    {
        // Get input from the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Calculate the movement amount
        Vector2 movementAmount = movementDirection * moveSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movementAmount);
    }
}
