using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostField : MonoBehaviour
{
    //FrostField is field effect that sets to true parameter in deck's of player who drive through it
    //Freeze effect is staple constant in Buff and Debaff component. This effect dosent allow player draw cards.
     private void Start()
    {
        StartCoroutine(DestroyAfterDelay()); //Start Coroutine to destroy itself 
    }

    //if player drive through find Buffandd Debuff manager and make it spawn freeze debuff
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BuffAndDebuffManager buffAndDebuffManager = FindObjectOfType<BuffAndDebuffManager>();
            if (buffAndDebuffManager != null)
            {
               buffAndDebuffManager.SpawnFreezePrefab();
            }
        }
    }
 
    // Destroy self after delay 
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
    
}
