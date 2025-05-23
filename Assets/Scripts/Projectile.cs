using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 10.0f;


    void FixedUpdate()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<SlimeController>().loseHealth(1);
        }

    }
}
