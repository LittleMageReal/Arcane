using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirages : MonoBehaviour
{
   //When you collide with yhis obgect, you draw random card 
   public List<Card> Boon; // list of card that can be obtained 
   [SerializeField] private Card randomCard; // card randomly selected from list

   void Start()
   {
    // Select a random card from the Boon list
      randomCard = Boon[Random.Range(0, Boon.Count)];
      Renderer renderer = GetComponent<Renderer>(); // Get the Renderer component of the current object
         switch (randomCard.pointType)
        {
         case Card.PointType.Green:
         renderer.material.color = Color.green; // Set the color to green
          break;
         case Card.PointType.Blue:
          renderer.material.color = Color.cyan; 
          break;
         case Card.PointType.Red:
          renderer.material.color = Color.magenta;
          break;
         }
   }

    //Draw random card on collision
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a Deck script
        Deck deck = other.gameObject.GetComponent<Deck>();

        if (deck!= null)
        {
            // Check if the player has any cards in their hand
            if (deck.hand.Count < 3)
            {
                // Add the selected card to the player's hand
                deck.AddCardToHand(randomCard);

                // Optionally destroy the collider after adding a card
                Destroy(gameObject);
            }
        }
    }
}
