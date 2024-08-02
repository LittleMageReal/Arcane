using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownOnCollision : MonoBehaviour
{
    // Slow down field effect 
    public float slowDownFactor = 0.5f; // Control how much the player should be slowed down
    public float scriptDisableDuration = 1f; // Control how long the player's script should be disabled

    // Slow down player speed while it inside 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
            playerRb.velocity *= slowDownFactor; // cut player speed via multiplying (can also give speed boost)
        }

    }

}

