using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public WillScript willScript;

    public float bulletForce = 20f;
    [SerializeField] private float Cooldown = 2f;
    private float lastUse;


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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Damage damage = bullet.GetComponent<Damage>();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }
}