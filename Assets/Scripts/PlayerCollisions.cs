using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    private GameManager manager;
    public PlayerController playerController;

    [Header("Events")]
    public Observer<bool> isHealing = new Observer<bool>(false);
    public Observer<bool> takingDamageFromTrap = new Observer<bool>(false);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            takingDamageFromTrap.Value = true;
            manager.loseHealth(1);
            playerController.knockBack(15f, 5f);
            takingDamageFromTrap.Value = false;
        }

        if (collision.gameObject.tag == "InstaKill")
        {
            manager.loseHealth(1000);
            // trigger death anim
        }

        if (collision.gameObject.tag == "HealthPickup")
        {
            isHealing.Value = true;
            manager.gainHealth(1);
            Destroy(collision.gameObject);
            isHealing.Value = false;
        }
        
        if(collision.gameObject.tag == "FinishLine")
        {
            manager.FinishLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        { 
            takingDamageFromTrap.Value = true;
            manager.loseHealth(1);
            playerController.knockBack(15f, 5f);
            takingDamageFromTrap.Value = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
