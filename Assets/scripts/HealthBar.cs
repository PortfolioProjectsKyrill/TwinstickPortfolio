using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int maxValue;
    public Image stat;
    public HealthComponent playerhealth;
    public void Start()
    {
        setMaxHealth(playerhealth.currentHealth);
    }

    public void setMaxHealth(int health)
    {
        maxValue = health;
    }

    public void SetHealth(int health)
    {
        stat.fillAmount = (float) health / (float) maxValue;
    }

    private void Update()
    {
        SetHealth(playerhealth.currentHealth);
    }
}
