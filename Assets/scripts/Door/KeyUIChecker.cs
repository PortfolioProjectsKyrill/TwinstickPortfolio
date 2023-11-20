using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIChecker : MonoBehaviour
{
    public GameObject RedKeyCanvas;
    public GameObject PurpleKeyCanvas;
    public GameObject GreenKeyCanvas;

    private Movement movement;
    void Start()
    {
        RedKeyCanvas.SetActive(false);
        PurpleKeyCanvas.SetActive(false);
        GreenKeyCanvas.SetActive(false);

        movement = FindObjectOfType<Movement>();//zoekt in hele scene
    }

    void Update()
    {
        RedKeyCanvas.SetActive(movement.hasRedKey);
        PurpleKeyCanvas.SetActive(movement.hasPurpleKey);
        GreenKeyCanvas.SetActive(movement.hasGreenKey);
    }
}
