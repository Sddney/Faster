using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player2_movement : MonoBehaviour
{

    public float height = 7f;

    private Vector2 movement;

    private Rigidbody2D rb;

    private Collider2D coll;

    public bool isGrounded = false;

    public bool isCrouching = false;

    private Vector2 full_scale = new Vector2(1f, 1f);

    private Vector2 crouching_scale = new Vector2(1f, 0.5f);

    public bool isJumping = false;
    public bool isFalling = false;

    private int jumping_counter = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumping_counter = 0;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator Scale_Return()
    {
        yield return new WaitForSecondsRealtime(1f);
        transform.localScale = new Vector2(5.69f, 5.69f);
        if (coll is BoxCollider2D boxCollider)
        {
           boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y + boxCollider.size.y * 0.5f);
           boxCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y * 2f);
        }
        isCrouching = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            if (jumping_counter < 2)
            {
                rb.AddForce(Vector2.up * height, ForceMode2D.Impulse);
            }
            transform.localScale = new Vector3(5.69f, 5.69f, 5.69f);
            Debug.Log("Jump");
            if (!isGrounded)
            {
                jumping_counter +=1;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isGrounded)
            {
                rb.AddForce(Vector2.down * height, ForceMode2D.Impulse);
                Debug.Log("Down");
            }
            else if (isGrounded && !isCrouching)
            {
                isCrouching = true;
                
                if (coll is BoxCollider2D boxCollider)
                {
                    boxCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y * 0.5f);
                    boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y - boxCollider.size.y * 0.5f);
                }
                
                StartCoroutine(Scale_Return());
            }
        }

        
        

    }

}
