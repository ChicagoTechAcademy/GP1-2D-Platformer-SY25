using TMPro;
using UnityEngine;

public class HealthTextUpdate : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI healthText;


    public void UpdateHealthText(int playerHealth)
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }

}
