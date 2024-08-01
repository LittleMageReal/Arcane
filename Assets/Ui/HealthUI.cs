using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health HealthScript; // Reference to the HealthScript
    public TMP_Text Health; // Reference to the UI Text object


    // Update is called once per frame
    void Update()
    {
       Health.text = HealthScript.Hp.ToString();
    }
}