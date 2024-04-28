using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private PlayerMovement playerMovement; // reference to our playermovement script.
    private PlayerMeleeAttack playerAttack;
    public string PlayerId { get; set; }
    // Find all player objects. This could be optimized if you have a list or dictionary.
    PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

    void Start()
    {

    }

    void Update()
    {
        if (PlayerId == GameManager.localPlayerId)
        {
            HandleLocalInput();
        }
        


    }

    private void HandleLocalInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
            playerMovement.TriggerJump();

        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            playerAttack.attack();
        }

        playerMovement.FlipAimation();
    }

    // This method is called when a command is received from the server
    public Task ExecuteCommandFromServer(string input, string playerId)
    {
        if (playerId != GameManager.localPlayerId)
        {
            foreach (var playerController in playerControllers)
            {
                if (playerController.PlayerId == playerId)
                {
                    // Execute the action based on the input
                    switch (input)
                    {
                        case "E":
                            // Insert action of E
                            break;
                        case "SPACE":
                            playerMovement.MultiplayerJump();
                            playerMovement.TriggerJump();
                            break;
                        case "A":
                            playerMovement.HandleMultiplayerInput();
                            break;
                        case "D":
                            playerMovement.HandleMultiplayerInput();
                            break;

                    }
                    break; // Exit the loop once the correct player is found and the action is executed
                }
            }

            return Task.CompletedTask;
        }
        else
        {
            Debug.Log("Error playerID was local id");
            return Task.CompletedTask;
        }
    }

    void OnDestroy()
    {

    }
}
