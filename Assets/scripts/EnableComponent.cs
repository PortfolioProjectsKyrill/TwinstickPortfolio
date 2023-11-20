using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableComponent : MonoBehaviour
{
    private Animator CustomComponent;

    void Start ()
    {
        CustomComponent = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.CapsLock))
        {
            CustomComponent.enabled = !CustomComponent.enabled;
        }
    }
}

