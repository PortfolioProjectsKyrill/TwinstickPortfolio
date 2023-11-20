using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    [SerializeField] private GameObject Player;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCam;

    public GunController theGun;

    public bool hasRedKey = false;
    public bool hasPurpleKey = false;
    public bool hasGreenKey = false;

    private AN_DoorKey an_doorkey;

    float distance;

    [SerializeField] private GameObject sceneKey;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
        an_doorkey = GetComponent<AN_DoorKey>();
    }

    void Update()
    {
        rb.velocity = moveVelocity;
        //Movement left and right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //Movement forward and backwards
        horizontalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);

        if (PauseMenu.gameIsPaused == false)
        {
            Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, new Vector3(0, this.transform.position.y, 0));
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
        }
    }

    private void DestroyKey()
    {
        //vernietigd de key als het in de inventory komt
        if (hasRedKey == true)
        {
            //dubbelchecken met andere variabele
            Destroy(sceneKey);
        }
        else if (hasPurpleKey == true)
        {
            //dubbelchecken met andere variabele
            Destroy(sceneKey);
        }
        else if (hasGreenKey == true)
        {
            //dubbelchecken met andere variabele
            Destroy(sceneKey);
        }
    }
}
