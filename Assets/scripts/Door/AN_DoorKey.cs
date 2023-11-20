using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_DoorKey : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    //Key gameObjects

    public bool isRedKey = true;
    public bool isPurpleKey = false;
    public bool isGreenKey = false;

    private doorAttempt2 DoorAttempt2Script;
    private Movement playerScript;

    // NearView()
    float distance;

    [SerializeField] private bool PlayerIsNear;

    private void Start()
    {
        /*hero = FindObjectOfType<AN_HeroInteractive>();*/ // key will get up and it will saved in "inventory"
        DoorAttempt2Script = GetComponent<doorAttempt2>();
        playerScript = GetComponent<Movement>();

    }

    void Update()
    {
        if (PlayerIsNear && Input.GetKeyDown(KeyCode.E) && isRedKey)
        {
            playerScript.hasRedKey = true;
            Destroy(gameObject);
        }
        if (PlayerIsNear && Input.GetKeyDown(KeyCode.E) && isGreenKey)
        {
            playerScript.hasGreenKey = true;
            Destroy(gameObject);
        }
        if (PlayerIsNear && Input.GetKeyDown(KeyCode.E) && isPurpleKey)
        {
            playerScript.hasPurpleKey = true;
            Destroy(gameObject);
        }
    }

    public bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 2f) return true;
        else return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerIsNear = true;
            playerScript = other.GetComponent<Movement>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerIsNear = false;
        }
    }
}
