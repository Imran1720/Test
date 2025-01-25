using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed;
    public float jumpForce;
    float xInput;


    public GameObject target;
    public float detectionDistance;
    public LayerMask whatIsGround;
    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        PlayerMovement();
        SetAnimations();
        Jump();
    }

    private void SetAnimations()
    {
        animator.SetFloat("YVelocity", rb.velocity.y);
        animator.SetFloat("XVelovity", MathF.Abs(rb.velocity.x));
        animator.SetBool("Grounded", GroundCheck());
    }

    private bool GroundCheck()
    {
        return Physics2D.Raycast(target.transform.position, Vector2.down, detectionDistance, whatIsGround);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void PlayerMovement()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

}
