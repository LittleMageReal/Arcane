using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBuff : MonoBehaviour
{
    //Earth Buff is a field Effect that add will to units on collision.
    public int willBoost = 200; //amount of will to add
    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    // Add unit Will on collision
    void OnTriggerEnter(Collider other)
    {
        var willscript = other.gameObject.GetComponent<WillScript>();
        if (willscript != null)
        {
            willscript.Will += willBoost;
        }
    }

    // Destroy field effect after some time 
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(40f);
        Destroy(gameObject);
    }
}
