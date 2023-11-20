using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public static bool hasPickedUpHealthPack = false;
    private bool hasEnteredTrigger = false;

    void Update()
    {
        if (hasEnteredTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPickedUpHealthPack = true;
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
        hasPickedUpHealthPack = false;
        hasEnteredTrigger = false;
    }
}
