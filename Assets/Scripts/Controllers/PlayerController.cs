using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private UDPClient udpClient;

    void Start()
    {
        // Initialize the UDP client
        udpClient = new UDPClient("127.0.0.1", 13000);
    }

    void Update()
    {
        // Capture player input
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);
        bool attackInput = Input.GetKeyDown(KeyCode.E);
        bool interactInput = Input.GetKeyDown(KeyCode.F);

        // Send the player input to the server
        udpClient.SendPlayerInput(horizontalInput, jumpInput, attackInput, interactInput);
    }

    void OnDestroy()
    {
        // Close the UDP client when the player object is destroyed
        udpClient.Close();
    }
}
