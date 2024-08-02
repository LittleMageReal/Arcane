using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    // Script to allow unit projectile set Crush in opponent to true. Crush deal damage to player when unit destroed
    private void OnCollisionEnter(Collision collision)
    {
        //Check if object have a will script and set crush to true
        WillScript willScript = collision.gameObject.GetComponent<WillScript>();
        if (willScript != null)
        {
            willScript.Crush = true;
        }
    }
}
