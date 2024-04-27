using UnityEngine;
using GameProject.Models;
using System.Threading.Tasks;


public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    float jumpAmount = 6.5f;
    // float climbSpeed = 3f;
    private bool isGrounded;
    private bool m_FacingRight = true;  // To know which way the player is currently facing.
    private Rigidbody2D rb;
    public Animator animator;
    private bool jump = false;
    //   bool jump = false;
    private TCPClient tcpClient;
    private Player player;
    private PlayerMovement[] playerMovements;

    public string PlayerId { get; set; }

    void Awake()
    {
        playerMovements = FindObjectsOfType<PlayerMovement>();

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tcpClient = FindObjectOfType<TCPClient>();


    }

    // Update is called once per frame
    void Update()
    {

        TriggerJump();
        FlipAimation();
        Jump();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");
        }
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")*moveSpeed));
    }

    // to move our charactor
    void FixedUpdate()
    {
       
            // Get horizontal input
            float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate movement vector
            Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

            // Apply movement
            rb.velocity = movement;

            // jump = false;

            CheckGrounded();
               

    }

    public async void HorizontalMovement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            await tcpClient.SendPlayerActionAsync("MOVE", "A", GameManager.localPlayerId, "{}");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            await tcpClient.SendPlayerActionAsync("MOVE", "D", GameManager.localPlayerId, "{}");

        }
        else
        {
            Debug.Log("Went past the send statement of the horizontal movement action");
        }
    }

    public async void MultiplayerJump()
    {        
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    public async void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("IM GROUNDED");
            // Apply jump force
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            if (GameManager.multiPlayer == true)
            {
                await tcpClient.SendPlayerActionAsync("MOVE", "SPACE", GameManager.localPlayerId, "{}");

            }
            else 
            {
                Debug.Log("Went past the send statement of the action");
            }
        }
    }

    public void CheckGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.Raycast(rb.position, Vector2.down, 1.4f, LayerMask.GetMask("Ground"));
        if (!isGrounded)
        {
            isGrounded = Physics2D.Raycast(rb.position, Vector2.right, 1.2f, LayerMask.GetMask("Ground"));
        }
        if (!isGrounded)
        {
            isGrounded = Physics2D.Raycast(rb.position, Vector2.left, 1.2f, LayerMask.GetMask("Ground"));
        }
    }        
        
    public void TriggerJump()
    {
        if (!Physics2D.Raycast(rb.position, Vector2.down, 1.2f, LayerMask.GetMask("Ground")))
        {
            jump = true;
            animator.SetBool("IsJumping", jump);
        }
        else if (Physics2D.Raycast(rb.position, Vector2.down, 1.2f, LayerMask.GetMask("Ground")))
        {
            jump = false;
            animator.SetBool("IsJumping", jump);
        }
    }

    public void FlipAimation()
    {
        // Check if the horizontal input direction corresponds with the character's facing direction
        float horizontalInput = Input.GetAxis("Horizontal");

        // Flip the player if moving left while facing right, or moving right while facing left
        if ((horizontalInput > 0 && !m_FacingRight) || (horizontalInput < 0 && m_FacingRight))
        {
            // Switch the direction the player is facing
            m_FacingRight = !m_FacingRight;

            // Flip the player's sprite horizontally
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    // This method is called when a command is received from the server
    public Task ExecuteCommandFromServer(string input, string playerId)
    {
        if (playerId != GameManager.localPlayerId)
        {
            foreach (var playerMovement in playerMovements)
            {
                if (playerMovement.PlayerId == playerId)
                {
                    // Execute the action based on the input
                    switch (input)
                    {
                        case "E":
                            // Insert action of E
                            break;
                        case "SPACE":
                            MultiplayerJump();
                            TriggerJump();
                            break;
                        case "A":
                            HorizontalMovement();
                            break;
                        case "D":
                            HorizontalMovement();
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


}