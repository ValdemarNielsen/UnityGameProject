using Codice.CM.Common;
using PlasticGui.WorkspaceWindow;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    float jumpAmount = 6;
    // float climbSpeed = 3f;
    private bool isGrounded;
    private bool m_FacingRight = true;  // To know which way the player is currently facing.
    private bool isLadder;
    private bool isClimbing;
    private Rigidbody2D rb;
    public Animator animator;
    private bool jump = false;
    //   bool jump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAttack();
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

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("IM GROUNDED");
            // Apply jump force
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

        }
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            Debug.Log("IM NOT GROUNDED");
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

    

    void Flip()
    {
        // Switch the direction the player is facing
        m_FacingRight = !m_FacingRight;

        // Flip the player's sprite horizontally
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void JumpAttack()
    {
        if (!Physics2D.Raycast(rb.position, Vector2.down, 1.2f, LayerMask.GetMask("Ground")) && Input.GetKeyDown(KeyCode.E)) {
                    
            animator.SetBool("JumpAttack", true);
            
        }
    } 
    void TriggerJump()
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

    void FlipAimation()
    {
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
            
}