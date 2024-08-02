using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artdraw : MonoBehaviour
{
    // Script to draw cards from use of artifact 
    public Deck deckScript;
    private int useCount = 3; // amount of uses
    private float Cooldown = 3f; 
    private float lastUse; // Time when last used

    private void Update()
       
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUse >= Cooldown) //cooldown 
        {
            // set time when object was used, draw one card and remove one use 
            lastUse = Time.time;
            deckScript.DrawCard(1);
            useCount--;

            if (useCount <= 0) // If the object has been used three times Destroy the object
            {
                Destroy(gameObject); 
            }
        }
        
    }
}
