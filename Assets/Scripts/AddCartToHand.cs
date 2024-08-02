using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCartToHand : MonoBehaviour
{
    // Script that when added to summoned unit add new card to the hand 
    public Card cardToAddWhenSummoned;

    private Deck deck;

    void Start()
    {
        // Find the deck in the parent object
        deck = GetComponentInParent<Deck>();

        // If the deck is found and the card to add is not null, add the card to the hand
        if (deck != null && cardToAddWhenSummoned != null)
        {
            deck.hand.Add(cardToAddWhenSummoned);
        }
    }

    void OnDestroy()
    {
        // If the unit is destroyed, remove the card from the hand
        if (deck != null && cardToAddWhenSummoned != null)
        {
            deck.hand.Remove(cardToAddWhenSummoned);
        }
    }
}
