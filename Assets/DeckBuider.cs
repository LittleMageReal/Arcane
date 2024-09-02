using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuider : MonoBehaviour
{
  public DeckListData HeroDeck;
  public List<Card> DeckList;
  public Card[] availableCards;

  public Button[] SelectButtons;
  public Button[] replaceButtons;
  public int number = 0;

  void Start()
  {
    // Initialize buttons
    InitializeButtons();

    // Set initial deck
    HeroDeck.cards = DeckList;
  }

    void InitializeButtons()
    {
      // Iterate through each button and set its onClick event
      for (int i = 0; i < SelectButtons.Length; i++)
      {
        int cardIndex = i; 

        // Add onClick event listener
        SelectButtons[i].onClick.RemoveAllListeners();
        SelectButtons[i].onClick.AddListener(() => ReplaceCard(cardIndex));
      }

      // Iterate through each button and set its onClick event
      for (int i = 0; i < replaceButtons.Length; i++)
      {
        int numberinDeck = i; // First button replaces first card,

        // Add onClick event listener
        replaceButtons[i].onClick.RemoveAllListeners();
        replaceButtons[i].onClick.AddListener(() => SetCard(numberinDeck));
      }
    }

    void ReplaceCard(int cardIndex)
    {
        if (availableCards.Length > 0 && DeckList.Count > 0)
        {
          DeckList[number] = availableCards[cardIndex];
          HeroDeck.cards = DeckList;
        }
    }

    void SetCard(int numberinDeck)
    {
      number = numberinDeck;
    }
}
