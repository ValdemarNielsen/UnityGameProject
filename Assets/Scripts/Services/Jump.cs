using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpAmount = 10;
    private bool isGrounded;
    public float moveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
            Debug.Log("IM GROUNDED");
            JumpNow();
    }

    }


    private void FixedUpdate()
    {       
        // Check if the player is grounded
        CheckGrounded();


    }
    void JumpNow()
    {
        // Apply jump force
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.Raycast(rb.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
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


