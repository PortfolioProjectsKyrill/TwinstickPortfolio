using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring = false;

    public float timeBetweenShots;
    private float shotCounter;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring == true)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
