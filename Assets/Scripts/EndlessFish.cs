using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFish : MonoBehaviour
{
    //Script for Fish unit. Fish unit can add two copy of Itself in deck 
    [SerializeField] private Card Fish;
    void Start()
    {
        var water = GetComponentInParent<Deck>();
        if (water != null)
        {
           water.deck.Add(Fish);
           water.deck.Add(Fish);
        }
        
    }

}
