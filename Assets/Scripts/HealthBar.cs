using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image redBar;
    public TextMeshProUGUI healthText;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        redBar.fillAmount = (float)currentHealth / (float)maxHealth;
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
