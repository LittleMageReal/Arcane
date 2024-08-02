using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    //Score managere instance for combo 
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }
    public UnityEvent OnScoreChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Change Score and invoke event to update ui
    public void AddPoints(int pointsToAdd)
    {
        Score += pointsToAdd;
        OnScoreChanged.Invoke(); // Invoke the event after changing the score
    }
}
