using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAttempt2 : MonoBehaviour
{
    private Animator _animator;
    private AN_DoorKey doorKey;
    private Movement playerScript;

    [SerializeField] private bool PurpleDoor = false;
    [SerializeField] private bool GreenDoor = false;
    [SerializeField] private bool RedDoor = false;

    [SerializeField] private GameObject Player;
    float distance;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        doorKey = GetComponent<AN_DoorKey>();
        playerScript = FindObjectOfType<Movement>();
    }

    private void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//kijkt of er een tag == player is
        {
            if (playerScript.hasRedKey && RedDoor == true)
            {
                _animator.SetBool("open", true);//zet de bool in de animator van doorAttempt2 op true
                //_animator.SetTrigger("open");
            }
            else if (playerScript.hasPurpleKey && PurpleDoor == true)
            {
                _animator.SetBool("open", true);//zet de bool in de animator van doorAttempt2 op true
                //_animator.SetTrigger("open");
            }
            else if (playerScript.hasGreenKey && GreenDoor == true)
            {
                _animator.SetBool("open", true);//zet de bool in de animator van doorAttempt2 op true
                //_animator.SetTrigger("open");
            }
        }
    }

    private void OnTriggerExit(Collider other)//activeert pas als je uit de box collider gaat
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("open", false);//zet de bool in de animator van doorAttempt2 op false
            /*_animator.SetTrigger("open");*/
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);//houd de afstand tussen gameObject en player bij (verandert per class)
        if (distance < 2f) return true;//als de afstand onder x is zegt hij ja
        else return false;//anders zegt hij nee
    }
}
