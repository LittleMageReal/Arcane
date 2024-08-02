using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnColli : MonoBehaviour
{
    //Script to Draw card from deck on collision
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a Deck script
        Deck deck = other.gameObject.GetComponent<Deck>();

        if (deck != null)
        {
            // Check if the player has any cards in their hand and draw one card if not 
            if (deck.hand.Count < 3)
            {
              deck.DrawCard(1);
              Destroy(gameObject);
            }
        }
    }
}

