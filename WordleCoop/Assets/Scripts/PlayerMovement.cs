using UnityEngine;
using System.Collections;
public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    private bool isGrounded;
    
    

     
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = rb.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (move < 0)
        {
            playerSprite.flipX = true;
        }
        else if (move > 0)
        {
            playerSprite.flipX = false;
        }

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Killer")
        {
            Destroy(gameObject);
        }      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
  public IEnumerator SpeedBoost(float extraSpeed, float duration)
    {
        moveSpeed += extraSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed -= extraSpeed;
    }
}