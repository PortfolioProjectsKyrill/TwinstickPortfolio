using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public static bool hasPickedUpArmorPack = false;
    private bool hasEnteredTrigger = false;

    void Update()
    {
        if (hasEnteredTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPickedUpArmorPack = true;
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
        hasPickedUpArmorPack = false;
        hasEnteredTrigger = false;
    }
}
