using Codice.CM.Common;
using PlasticGui.WorkspaceWindow;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    float jumpAmount = 6;
    private bool isGrounded;
    private bool m_FacingRight = true;  // To know which way the player is currently facing.
    private Rigidbody2D rb;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")*moveSpeed));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("IM GROUNDED");
            Jump();
          //  animator.SetBool("IsJumping", true);
        }
        if ( Input.GetKeyDown(KeyCode.Space) && !isGrounded )
        {
            Debug.Log("IM NOT GROUNDED");
        }

        // Update facing direction based on horizontal input
        if (Input.GetAxis("Horizontal") > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (Input.GetAxis("Horizontal") < 0 && m_FacingRight)
        {
            Flip();
        }

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

        CheckGrounded();

    }

    void Jump()
    {
        // Apply jump force
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    void CheckGrounded()
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

    

    void Flip()
    {
        // Switch the direction the player is facing
        m_FacingRight = !m_FacingRight;

        // Flip the player's sprite horizontally
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}