using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    //Freeze effect is staple constant in Buff and Debaff component. This effect dosent allow player draw cards.
    // When spawned set deck freeze to true in parent 
    private void Update()
    {
        var deck = GetComponentInParent<Deck>();
        if (deck != null)
        {
            deck.FreezeDeck = true; 
        }
        StartCoroutine(DestroyAfterDelay());
    }

    // Set deck freeze to false and destroy self in some time 
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(7f); // some time 
        var deck = GetComponentInParent<Deck>();
        if (deck != null)
        {
            deck.FreezeDeck = false; 
        }
        Destroy(gameObject);
    }
}
