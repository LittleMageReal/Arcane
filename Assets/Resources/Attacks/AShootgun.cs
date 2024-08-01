using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AShootgun : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public WillScript willScript;

    public float bulletForce = 20f;
    public float spreadAngle = 10f; // Angle for bullet spread

    [SerializeField] private float Cooldown = 2f;
    private float lastUse;

   

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetButtonDown("Fire1") && Time.time - lastUse >= Cooldown)
            {
                lastUse = Time.time;
                Shoot();
            }
        
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Damage damage = bullet.GetComponent<Damage>();

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
        }
    }
}
