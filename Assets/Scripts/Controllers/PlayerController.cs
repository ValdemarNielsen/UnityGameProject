using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private UDPClient udpClient;
    private PlayerMovement playerMovement; // reference to our playermovement script.
    private PlayerMeleeAttack playerAttack;
    private UpDoor upDoor;
    public string PlayerId { get; set; }
    // Find all player objects. This could be optimized if you have a list or dictionary.
    PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

    void Start()
    {
        // Initialize the UDP client
        udpClient = new UDPClient("127.0.0.1", 13000);
    }

    void Update()
    {
        
        if (PlayerId == GameManager.localPlayerId)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.JumpAttack();
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
    }

    // This method is called when a command is received from the server
    public async Task ExecuteCommandFromServer(string playerId, string input, string message)
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
                    case "Space":
                        playerMovement.JumpAttack();
                        playerMovement.Jump();
                        playerMovement.TriggerJump();
                        break;

                        // Handle other inputs...
                }
                break; // Exit the loop once the correct player is found and the action is executed
            }
        }
    }

    
    void OnDestroy()
    {
        // Close the UDP client when the player object is destroyed
        udpClient.Close();
    }
}
