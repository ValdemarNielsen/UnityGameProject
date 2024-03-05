using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    float jumpAmount = 6;
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
        if ( Input.GetKeyDown(KeyCode.Space) && !isGrounded )
        {
            Debug.Log("IM NOT GROUNDED");
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

        CheckGrounded();

    }

    void Jump()
    {
        // Apply jump force
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    void CheckGrounded()
    {
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
}