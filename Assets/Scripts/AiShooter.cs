using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShooter : MonoBehaviour
{
    public Transform player; // The transform of the player game object.
    public Transform firepoint;
    public GameObject projectile; // The projectile prefab.
    public float range = 10f; // The maximum range at which the turret can fire.
    public float fireInterval = 0.5f; // The interval at which the turret fires, in seconds.
    public float speed = 1.0f; // The speed of rotation.
    public float firespeed = 20;

    private float lastFireTime; // The time at which the turret last fired.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
         float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= range && Time.time - lastFireTime >= fireInterval)
         {
          FireShot();
          lastFireTime = Time.time;
         }

         // Rotate the turret so that it always faces the player.
         Vector3 targetDirection = player.position - transform.position;
         float singleStep = speed * Time.deltaTime;
         Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
         Quaternion rotation = Quaternion.LookRotation(newDirection);

         // Remove rotation around the Y-axis
         Vector3 eulerRotation = rotation.eulerAngles;
         eulerRotation.x = 0; // Zero out the Y component
         transform.rotation = Quaternion.Euler(eulerRotation);
    }

    void FireShot()
    {
        // Instantiate the projectile at the turret's position and in the direction of the player.
        GameObject newProjectile = Instantiate(projectile, firepoint.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody>().AddForce((player.position - transform.position) * firespeed, ForceMode.Impulse);
    }
}
