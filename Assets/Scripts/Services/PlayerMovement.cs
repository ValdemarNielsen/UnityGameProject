using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 2.5f;
    public float jumpAmount = 10;
    private bool isGrounded;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("IM GROUNDED");
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Apply movement
        rb.velocity = movement;

        // Check if the player is grounded
        CheckGrounded();


    }
    void Jump()
    {
        // Apply jump force
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.Raycast(rb.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        if (!isGrounded)
        {
            isGrounded = Physics2D.Raycast(rb.position, Vector2.right, 2f, LayerMask.GetMask("Ground"));
        }
        if (!isGrounded)
        {
            isGrounded = Physics2D.Raycast(rb.position, Vector2.left, 2f, LayerMask.GetMask("Ground"));
        }
    }
}
