using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseinput : MonoBehaviour
{
    // Script for player mouse input
    public Spawn spawnscript;

    private float rightMouseHoldStartTime =  0f; // Time when the right mouse button was first pressed
    public bool isRightMouseHeld = false; // Whether the right mouse button is currently being held down


    
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        spawnscript.Scrolling(scroll);
        

         // Card summoning and Activated in hand effects
         if (Input.GetButtonDown("Fire2")) 
            {
                isRightMouseHeld = true;

                rightMouseHoldStartTime = Time.time;
            }

         if (Input.GetButtonUp("Fire2"))
            {
                if (Time.time - rightMouseHoldStartTime >= 3f)
                {
                    spawnscript.ReturnCardAndDrawNew();
                }
                else
                {
                    Card selectedCard = spawnscript.deck.hand[spawnscript.selectedCardIndex];
                    spawnscript.SpawnPrefab(selectedCard);
                }

                isRightMouseHeld = false;
           }
    }
}
