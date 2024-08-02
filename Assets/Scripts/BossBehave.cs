using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehave : MonoBehaviour
{
    // Script for Boss Behavior 

    public GameObject bulletPrefab; 
    public float speed = 90f; // Speed at which the boss rotates
    [SerializeField] private int Attack; // Amount of damage 
    public Transform[] firePoints; 
    public float Cooldown = 2; // amount of time before next bullet shot 
    public float bulletForce = 20f; // Speed of projectile

    public bool shouldContinueAttacking = false; // bool to check if unit awake
    public WillScript power;
    public int CurentPowah; // current amount of will

    private void Start()
    {
        Awoken();
    }

    private void Update()
    { 
        // Check if will power more than 0 and unit can attack
        if(CurentPowah != power.Will && !shouldContinueAttacking)// Check if unit will amount is changed 
        {
            Awoken();
            CurentPowah = power.Will; // set new current will
        }
        else
        {
            IsDormant();
        }
    }

    // Attack coroutine
    IEnumerator SpawnBullets()
    {
        // Initial delay
        yield return new WaitForSeconds(7);
        
        // Calculate rotation speed for a full circle in 2 seconds
        float rotationSpeed = 360f / 2; // Degrees per second
        
        // Start time
        float startTime = Time.time;

        while (shouldContinueAttacking) // Infinite loop for continuous behavior
        {
            // Rotate the boss
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Check if 2 seconds have passed since the last bullet was shot
            if (Time.time >= startTime + Cooldown)
            {
                // Reset start time for next bullet
                startTime = Time.time;

                foreach (Transform firePoint in firePoints)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                    Damage damage = bullet.GetComponent<Damage>();

                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
                }
            }

            // Wait for 1 frame before continuing the loop
            yield return null;
        }
    }
 
   public void Awoken() //make unit active
   {
      shouldContinueAttacking = true;
      StartCoroutine(SpawnBullets());
   }

  void IsDormant() //make unit inactive
  {
    CurentPowah = power.Will;
    switch(CurentPowah) // if current will is 0 stop attack 
    {
     case 0:
      StopAttacking();
      break;
    }
  }
   public void StopAttacking() 
   {
      shouldContinueAttacking = false;
   }

}
