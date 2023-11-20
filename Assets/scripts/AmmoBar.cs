using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    int maxValue;
    public Image stat;
    public Shooting playerammo;
    public void Start()
        {
        setMaxAmmo(playerammo.currentAmmo);
        }

        public void setMaxAmmo(int Ammo)
        {
            maxValue = Ammo;
        }

        public void SetAmmo(int Ammo)
        {
        stat.fillAmount = (float)Ammo / (float)maxValue;
        }

        private void Update()
    {
        SetAmmo(playerammo.currentAmmo);    
    }
}
