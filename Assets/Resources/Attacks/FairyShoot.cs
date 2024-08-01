using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public WillScript willScript;

    public float bulletForce = 20f;
    [SerializeField] private float Cooldown = 2f;
    private float lastUse;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetButtonDown("Fire1") && Time.time - lastUse >= Cooldown)
            {
                lastUse = Time.time;
                StartCoroutine(Shoot());
            }
        

    }

    IEnumerator Shoot()
    {
        int numberOfBullets = 5;
        float delay = 0.1f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Damage damage = bullet.GetComponent<Damage>();

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);

            yield return new WaitForSeconds(delay);
        }
        
    }
}
