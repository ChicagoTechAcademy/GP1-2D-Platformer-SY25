using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private PlayerController player;
    public Observer<int> Health = new Observer<int>(3);
    public Observer<bool> isLiving = new Observer<bool>(true);

    public Observer<bool> WonGame = new Observer<bool>(false);

    [SerializeField] private TextMeshProUGUI winText;

    void Start()
    {
        Health.Invoke();
    }

    public void loseHealth(int healthToLose)
    {
        if(Health.Value > 0)
        {
            Health.Value = Health.Value - healthToLose;
        }
        HealthCheck();
    }

    public void gainHealth(int healthToGain)
    {
        Health.Value = Health.Value + healthToGain;
    }

    public void FinishLevel()
    {
        winText.gameObject.SetActive(true);
        WonGame.Value = true;
        Invoke(nameof(RestartLevel), 5f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HealthCheck()
    {
        if (Health.Value <= 0 && isLiving.Value == true)
        {
            player.PlayerDeath();
            isLiving.Value = false;
            Invoke(nameof(RestartLevel), 3f);
        }
    }

}
