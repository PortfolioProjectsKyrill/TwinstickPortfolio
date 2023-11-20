using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int maxHealth = 30;
    [SerializeField] public int currentHealth = 30;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            currentHealth -= 10;
            if (currentHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
