
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private PlayerController player;
    public Observer<int> Health = new Observer<int>(3);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health.Invoke();
    }

    public void loseHealth(int healthToLose)
    {
        Health.Value = Health.Value - healthToLose;
        HealthCheck();
    }

    public void gainHealth(int healthToGain)
    {
        Health.Value = Health.Value + healthToGain;
    }

    
    private void HealthCheck()
    {
        if(Health.Value <= 0)
        {
            player.PlayerDeath();
        }
    }

}
