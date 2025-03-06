using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{

    /* TODO:
        Fix jump height
        Organize the variables on this script
        Implement Fall
        Basic Camera Follow
        Checkpoint: Create 3 platforms that the character can jump on to.
    */


    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;


    [Header("Movement Values")]
    public float movementSpeed = 5.0f;
    public float jumpForce = 5.0f;
    [Range(0.1f, 1.0f)]
    [SerializeField] private float groundCheckRadius = 0.1f;
    private float horizontalMove = 0;


    [Header("Flags")]
    private bool isFacingRight = true;
    private bool isJumping = false;
    private bool isGrounded = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocityY);

        if (isJumping == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            isJumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (horizontalMove != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


        if (horizontalMove > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && isFacingRight)
        {
            Flip();
        }

        //jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        // handles the fall animation
        if(isGrounded == false && rb.linearVelocityY < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

    }

    public void PlayerDeath()
    {
        animator.SetBool("isDead", true);
        Destroy(this.gameObject, 1.0f);
    }

    public void knockBack(float knockLeft, float knockUp)
    {
        rb.linearVelocity = new Vector2(-knockLeft, knockUp);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void Flip()
    {
        if (isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (!isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
