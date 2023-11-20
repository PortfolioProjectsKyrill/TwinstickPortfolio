using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private int healthPackValue = 40;
    private int armorPackValue = 50;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    //Health
    private int maxHealth = 50;
    [SerializeField] public int currentHealth = 50;

    //Shield
    private int maxShield = 50;
    [SerializeField] public int currentShield = 0;

    // Update is called once per frame
    void Update()
    {
        if (HealthPickUp.hasPickedUpHealthPack)
        {
            currentHealth = currentHealth + healthPackValue;
            HealthPickUp.hasPickedUpHealthPack = false;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        if (ShieldPickUp.hasPickedUpArmorPack)
        {
            currentShield = currentShield + armorPackValue;
            ShieldPickUp.hasPickedUpArmorPack = false;

            if (currentShield > maxShield)
            {
                currentShield = maxShield;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            currentHealth -= 10;
            if (currentHealth == 0)
            {
                player.transform.position = respawnPoint.transform.position;
                currentHealth = maxHealth;
            }
        }
    }
}
