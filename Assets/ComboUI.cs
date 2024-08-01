using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class ComboUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Combotext;


    private void Start()
    {
        // Subscribe to the OnScoreChanged event
        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScore);
    }

    public void UpdateScore()
    {
        Combotext.text = ScoreManager.Instance.Score.ToString();
    }

     private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        ScoreManager.Instance.OnScoreChanged.RemoveListener(UpdateScore);
    }
}
