using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 10f;
    public float distanceX = 2.0f;
    public float distanceY = 0;

    Vector3 aPos;
    Vector3 bPos;

    Vector3 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aPos = transform.position + new Vector3(distanceX, distanceY, 0);
        bPos = transform.position + new Vector3(-distanceX, -distanceY, 0);

        target = aPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToA = Vector3.Distance(transform.position, aPos);
        float distanceToB = Vector3.Distance(transform.position, bPos);

        if(distanceToA == 0)
        {
            target = bPos;
        }
        if(distanceToB == 0)
        {
            target = aPos;
        }

        float step = speed * Time.deltaTime; // calculates the distance it should move this frame
        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }

}
