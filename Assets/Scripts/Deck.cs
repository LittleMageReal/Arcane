using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //Deck script for card scriptable objects. Deck script navigates hand and deck logic. Card used in hand set as last card in deck
    public List<Card> deck;
    public List<Card> hand = new List<Card>();
    public bool FreezeDeck = false;

    // Shaffle and draw card in begining if need so
    void Start()
    { 
       ShuffleDeck();
       DrawCard(0);
    }

    void ShuffleDeck() // just randomaze a deck 
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void DrawCard(int numberOfCards)
    {
       for (int i = 0; i < numberOfCards; i++)
        {
            // Check if the hand is already full
            if (hand.Count >= 3 && FreezeDeck == false) //hand limit 
            {
                break; 
            }

            if (deck.Count > 0 && FreezeDeck == false) // add first card in deck list to hand list 
            {
                Card drawnCard = deck[0];
                deck.RemoveAt(0);
                hand.Add(drawnCard);    
            }
        }
    }

    public void ReturnCard(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            // Check if the hand is already full
            if (hand.Count >= 3) //hand limit 
            {
                break;
            }

            if (deck.Count > 0)
            {
                Card drawnCard = deck[deck.Count - 1]; // Get the last card in the deck
                deck.RemoveAt(deck.Count - 1); // Remove the last card from the deck
                hand.Add(drawnCard); // Add this card to the hand
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Finish")
        {
            // Draw a full hand of cards
            DrawCard(3);
        }
    }

    public void AddCardToHand(Card card) // To add cards from other places than the deck 
    {
       hand.Add(card);
    }

}
