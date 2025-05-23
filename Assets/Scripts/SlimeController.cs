using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public int health = 2;
    public float speed = 10.0f;
    public Transform groundChecker;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Animator animator;

    private bool isGrounded;
    private bool isFacingRight = false;

    void FixedUpdate()
    {
        if(isGrounded == true)
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        if(isGrounded == false)
        {
            Flip();
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundLayer);
    }

    public void loseHealth(int healthToLose)
    {
        health = health - healthToLose;

        if (health <= 0)
        {
            destroyEnemy();
        }
    }

    public void destroyEnemy()
    {
        speed = 0;
        animator.SetBool("isDead", true);
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChecker.position, .1f);
    }
}
