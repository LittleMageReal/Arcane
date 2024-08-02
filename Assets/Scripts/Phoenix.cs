using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    //Phonix unit script. Phoenix Heal player when sumonned and returns to hand after attack( actually destroy itself and draw card from bottom )
    public int healAmount = 100; // The amount of HP to heal
    public Deck deckScript;

    void Start()
    {
        // Find the Health component in the scene
        Health health = GetComponentInParent<Health>();
        deckScript = GetComponentInParent<Deck>();

        // Call the GainHealth method
        if (health != null)
        {
            health.GainHealth(healAmount);
        }
    }
    
    // destroy itself after attack and draw last played card
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) //cooldown 
        {
            Destroy(gameObject); 
            deckScript.ReturnCard(1);
        }
    }
}
