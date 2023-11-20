using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public static bool hasPickedUpAmmo = false;
    private bool hasEnteredTrigger = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (hasEnteredTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPickedUpAmmo = true;
                hasEnteredTrigger = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasEnteredTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hasPickedUpAmmo = false;
        hasEnteredTrigger = false;
    }
}
