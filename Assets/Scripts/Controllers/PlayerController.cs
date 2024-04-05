using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private UDPClient udpClient;
    private PlayerMovement playerMovement; // reference to our playermovement script.
    private PlayerMeleeAttack playerAttack;
    public string PlayerId { get; set; }


    void Start()
    {
        // Initialize the UDP client
        udpClient = new UDPClient("127.0.0.1", 13000);
    }

    void Update()
    {
        
        if (PlayerId == GameManager.localPlayerId)
        {
            playerMovement.JumpAttack();
            playerMovement.TriggerJump();
            playerMovement.FlipAimation();
            playerMovement.Jump();
            playerAttack.attack();

        }              
    }


    void OnDestroy()
    {
        // Close the UDP client when the player object is destroyed
        udpClient.Close();
    }
}
