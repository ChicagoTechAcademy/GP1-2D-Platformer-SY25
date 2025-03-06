using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    private GameManager manager;
    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            manager.loseHealth(1);
            playerController.knockBack(15f, 5f);
        }

        if(collision.gameObject.tag == "InstaKill")
        {
            manager.loseHealth(1000);
            // trigger death anim
        }

        if(collision.gameObject.tag == "HealthPickup")
        {
            manager.gainHealth(1);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
