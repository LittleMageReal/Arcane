using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedAttack : MonoBehaviour
{
    //Script that give unit ability to hold attack and increase power(can be merged as a function in just attack script)
    public Transform firePoint;
    public GameObject bulletPrefab;
    public WillScript willScript;

    public float maxHoldDuration = 3f; // Maximum duration to consider as "holding"
    private float buttonPressStartTime = 0f; // Time when the button was first pressed
    private Coroutine chargeCoroutine;

    public float bulletForce = 20f;

    
  //press attack to shoot , hold to gain power up 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            buttonPressStartTime = Time.time;
            chargeCoroutine = StartCoroutine(ChargeAfterDelay());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (Time.time - buttonPressStartTime < maxHoldDuration)
            {
                StopCoroutine(chargeCoroutine);
                Shoot();
            }
        }
    }
    // Start counting up to 3 when button is held
    IEnumerator ChargeAfterDelay()
    {
        yield return new WaitForSeconds(maxHoldDuration);
        Charge();
    }

    void Charge()
    {
        // increase the will
        willScript.Will += 200;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Damage damage = bullet.GetComponent<Damage>();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }
}
