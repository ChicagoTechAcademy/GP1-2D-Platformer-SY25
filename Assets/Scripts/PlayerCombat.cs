using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{

    public Projectile projectilePrefab;
    public Transform projectileSpawnPoint;

    public Observer<bool> launchProjectile = new Observer<bool>(true);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            projectileAttack();
        }
    }

    void projectileAttack()
    {
        launchProjectile.Value = true;
        Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        launchProjectile.Value = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(projectileSpawnPoint.position, .1f);
    }
}
