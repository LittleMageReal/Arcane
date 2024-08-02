using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnClock : MonoBehaviour
{
    // Draw card from the bottom of a deck 
    public Deck deckScript;
    [SerializeField] private int useCount = 3;
    private float scrollCooldown = 3f;
    private float lastUse;

    public void Start()
    {
        deckScript = GetComponentInParent<Deck>();
    }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUse >= scrollCooldown) //cooldown 
            {
                lastUse = Time.time;
                deckScript.ReturnCard(1); // Function in deck
                useCount--;

                if (useCount <= 0) // If the object has been used three times
                {
                  Destroy(gameObject); // Destroy the object
                }
            }

    }
}
