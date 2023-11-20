using System.Collections;
using UnityEngine;

public class Shooting : TestDeathBox
{
    private int ammoValue = 12;

    public int currentAmmo;
    public float reloadTime = 5f;
    public float fireRate = 15f;
    public float projectileSpeed = 10f;
    private float nextTimeToFiring = 1f;
    private bool isReloading = false;
    public int startMaxAmmo = 0;
    public int maxCapacity = 36;
    public int maxAmmo = 12;

    public Ammo bullet;
    public float bulletSpeed;

    public Transform firePoint;

    void Start()
    {
        currentAmmo = startMaxAmmo;
    }

    void Update()
    {
        if (AmmoPickUp.hasPickedUpAmmo)
        {
            currentAmmo = currentAmmo + ammoValue;
            AmmoPickUp.hasPickedUpAmmo = false;

            if (currentAmmo > maxAmmo)
            {
                currentAmmo = maxAmmo;
            }
        }

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            //Start the coroutine
            Reload();
            return;
        }

        //LMB Firing
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFiring)
        {
            nextTimeToFiring = Time.time + 4f / fireRate;
            Shoot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Damage
        if (collision.gameObject.tag == "Damage")
        {
            currentHealth -= 10;
            if (currentHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Reload()
    {
        //Set reloading to true
        isReloading = true;

        Debug.Log("Reloading...");

        //Wait for 5 seconds before reloading is done
        yield return new WaitForSeconds(reloadTime);
        

        Debug.Log("Full ammo");
        //Ammo is full and can shoot again
        currentAmmo = maxAmmo;
        //Exit reloading mode and set it to false
        isReloading = false;
    }

    public void Shoot()
    {
        currentAmmo--;
        Ammo newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Ammo;
        newBullet.projectileSpeed = bulletSpeed;
    }
}
 