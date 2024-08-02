using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkShoot : MonoBehaviour
{
    // Shoot bullet in ark (dosent work as intended, think there better ways to do it, but i didnt find yet )
    public Transform firePoint;
    public GameObject bulletPrefab;
    public WillScript willScript;

    public float bulletForce = 20f;


    // Update is called once per frame
    void Update()
    {
       
      if (Input.GetButtonDown("Fire1"))
       {
          Shoot();
       }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Damage damage = bullet.GetComponent<Damage>();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Calculate the direction of the force
        Quaternion direction = Quaternion.Euler(new Vector3(90, 0, 90)); // Adjust the angle as needed

        // Apply the force in the calculated direction
        rb.AddForce(direction * firePoint.up * bulletForce, ForceMode.Impulse);
    }
}
