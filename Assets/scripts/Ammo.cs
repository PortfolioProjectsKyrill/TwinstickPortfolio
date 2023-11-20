using UnityEngine;

public class Ammo : Shooting
{
    void Start()
    {

    }

    void Update()
    {
        //Shooting forward
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Props" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
