using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    int maxValue;
    public Image stat;
    public HealthComponent playerarmor;
    public void Start()
    {
        setMaxArmor(playerarmor.currentShield);
    }

    public void setMaxArmor(int Armor)
    {
        maxValue = Armor;
    }

    public void SetArmor(int Armor)
    {
        stat.fillAmount = (float)Armor / (float)maxValue;
    }

    private void Update()
    {
        SetArmor(playerarmor.currentShield);
    }
}
