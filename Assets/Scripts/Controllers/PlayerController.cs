using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private UDPClient udpClient;
    public string PlayerId { get; set; }


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

        if(horizontalInput != 0)
        {
            // Send the player input to the server
            udpClient.SendPlayerInput(horizontalInput, jumpInput, attackInput, interactInput);
            Debug.Log("this is the horizontal input and jump input " + horizontalInput);
        }
        
    }

    void OnDestroy()
    {
        // Close the UDP client when the player object is destroyed
        udpClient.Close();
    }
}
