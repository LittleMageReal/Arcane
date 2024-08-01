using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Retire : MonoBehaviour
{
    public Health Health;
    public Spawn UnitSpawn;
    public KArtController Control;
    public GameObject RetireUi;

    private void Start()
    {
        {
            // Find the "hp" text object and assign it to the Health variable
            RetireUi = GameObject.Find("Retire");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Health.Hp <= 0)
        {
            foreach (Transform child in RetireUi.transform)
            {
                child.gameObject.SetActive(true);
            }
            UnitSpawn.enabled = false;
            Control.enabled = false;
        }
    }
}
