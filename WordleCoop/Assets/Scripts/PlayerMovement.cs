using UnityEngine;
using System.Collections;
public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    public int trampolineBoost = 15000;

    public Animator trampolineAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

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

        if (collision.gameObject.tag == "Tramp")
        {
            Debug.Log("ITS HERE");
            StartCoroutine(Trampoline());
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
    
    public IEnumerator Trampoline()
    {
        trampolineAnim.SetBool("isActive", true); 
        Debug.Log("Boing");
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(new Vector2(0, 1 * trampolineBoost));
        yield return new WaitForSeconds(1);
        trampolineAnim.SetBool("isActive", false); 
        Debug.Log("No Boing");

    }
}