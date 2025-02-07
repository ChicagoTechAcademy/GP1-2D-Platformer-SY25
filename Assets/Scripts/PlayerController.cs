using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator animator;
    private float horizontalMove = 0;
    private bool isFacingRight = true;
    public float movementSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocityY);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

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
}
