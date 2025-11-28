using UnityEngine;

public class animation2 : MonoBehaviour
{
    private Animator animator;

    public player2_movement player2_movement;

    private Rigidbody2D rb;

    public bool isFlying = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (player2_movement.isJumping)
        {
            animator.SetBool("goingUp", true);
            isFlying = true;
            
        }
        else
        {
            animator.SetBool("goingUp", false);
        }

        if (isFlying)
        {
            animator.SetBool("is_flying", true);
            player2_movement.isJumping = false;
            
        }

        if (rb.linearVelocity.y < -0.0001f)
        {
            animator.SetBool("is_flying", false);
            animator.SetBool("is_falling", true);

        }
        if (player2_movement.isGrounded)
        {
            animator.SetBool("to_ground", true);
        }
        else
        {
            animator.SetBool("to_ground", false);
        }

        if (player2_movement.isCrouching)
        {
            animator.SetBool("is_sliding", true);
        }
        else
        {
            animator.SetBool("is_sliding", false);
        }



    }
}
