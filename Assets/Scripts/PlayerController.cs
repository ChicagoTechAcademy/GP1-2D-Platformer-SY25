using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /* TODO:
        Fix jump height
        Organize the variables on this script
        Implement Fall
        Basic Camera Follow
        Checkpoint: Create 3 platforms that the character can jump on to.
    */


    private Rigidbody2D rb;
    public Animator animator;
    private float horizontalMove = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isFacingRight = true;
    private bool isJumping = false;
    private bool isGrounded = false;
    private float groundCheckRadius = 0.1f;
    public float movementSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocityY);

        if(isJumping == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 5);
            isJumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(horizontalMove != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }


        if(horizontalMove > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(horizontalMove < 0 && isFacingRight)
        {
            Flip();
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void Flip()
    {
        if(isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(!isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
