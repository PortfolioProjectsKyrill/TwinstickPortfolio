using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeathBox : MonoBehaviour
{
    private int maxHealth = 50;
    [SerializeField] public int currentHealth = 50;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Health(int adjust)
    {
        currentHealth += adjust;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
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
