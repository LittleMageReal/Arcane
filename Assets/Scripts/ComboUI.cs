using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ComboUI : MonoBehaviour
{
    // Script to update ComboCounterUI
    [SerializeField] TextMeshProUGUI Combotext;

    // Subscribe to the OnScoreChanged event
    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScore);
    }

    // Update Text object to actual score
    public void UpdateScore()
    {
        Combotext.text = ScoreManager.Instance.Score.ToString();
    }

    // Unsubscribe from the event when the object is destroyed
     private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChanged.RemoveListener(UpdateScore);
    }
}
