using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Rigidbody2D rbJump;
    public float jumpAmount = 10;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rbJump = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        isGrounded = false;
        rbJump.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }
    }


    private void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(rbJump.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
    }
}
