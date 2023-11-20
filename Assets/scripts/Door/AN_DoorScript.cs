using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState
{
    Closed,
    Open
}
public class AN_DoorScript : MonoBehaviour
{
    public bool Locked = false;
    public bool Remote = false;
    public bool CanOpen = true;
    public bool CanClose = true;
    public bool RedLocked = false;
    public bool BlueLocked = false;
    AN_HeroInteractive HeroInteractive;
    public bool isOpened = false;
    [Range(0f, 4f)]
    public float OpenSpeed = 3f;

    [SerializeField] private GameObject Player;

    private AnimState animState;
    [SerializeField] private Behaviour StuffToTurnOn;
    private Animator animator;

    //NearView()
    float distance;

    //Hinge
    [HideInInspector]
    public Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;
    float currentLim;

    void Start()
    {
        rbDoor = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        HeroInteractive = FindObjectOfType<AN_HeroInteractive>();
        animator = FindObjectOfType<Animator>();
    }

    void Update()
    {
        //if (!Remote && Input.GetKeyDown(KeyCode.E) && NearView())
        //{

        //}
    }

    //public void Action() //void to open/close door
    //{
    //    if (!Locked)
    //    {
    //        // key lock checking
    //        if (HeroInteractive != null && RedLocked && HeroInteractive.RedKey)
    //        {
    //            RedLocked = false;
    //            HeroInteractive.RedKey = false;
    //        }
    //        else if (HeroInteractive != null && BlueLocked && HeroInteractive.BlueKey)
    //        {
    //            BlueLocked = false;
    //            HeroInteractive.BlueKey = false;
    //        }

    //        // opening/closing
    //        if (isOpened && CanClose && !RedLocked && !BlueLocked)//het open is, dicht kan, niet geredlocked, niet gebluelocked. ALS HET OPEN IS
    //        {
    //            isOpened = false;
    //        }
    //        else if (!isOpened && CanOpen && !RedLocked && !BlueLocked)//niet geopend, kan openen, niet geredlocked, niet gebluelocked. ALS HET DICHT IS
    //        {
    //            isOpened = true;
    //            //rbDoor.AddRelativeTorque(new Vector3(0, 0, 40f));
    //        }
    //    }
    //}

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 3f) return true;
        else return false;

    }

    //private void FixedUpdate() // door is physical object
    //{
    //    if (isOpened)
    //    {
    //        currentLim = 85f;
    //    }
    //    else
    //    {
    //        // currentLim = hinge.angle; // door will closed from current opened angle
    //        if (currentLim > 1f)
    //            currentLim -= .5f * OpenSpeed;
    //    }

    //    // using values to door object
    //    //hingeLim.max = currentLim;
    //    //hingeLim.min = -currentLim;
    //    //hinge.limits = hingeLim;
    //}

    private void OnTriggerEnter(Collider other)
    {

    }
}
