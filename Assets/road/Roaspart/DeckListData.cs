using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card List", menuName = "Card List")]

public class DeckListData : ScriptableObject
{
    public List<Card> cards;
}
