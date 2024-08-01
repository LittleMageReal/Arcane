using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Syringe : MonoBehaviour
{
    
    [SerializeField] private int useCount = 2;
    private float scrollCooldown = 3f;
    private float lastUse;
    [SerializeField] GameObject childObject;
    [SerializeField] GameObject grandparentObject;
    private int rememberedWill;
    private int setwill = 0;

    public void Start()
    {
        grandparentObject = childObject.transform.parent.parent.gameObject;
    }

    private void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUse >= scrollCooldown) //cooldown 
            {
                lastUse = Time.time;
                Syrge();
                useCount--;

                if (useCount <= 0) // If the object has been used three times
                {
                    Destroy(gameObject); // Destroy the object
                }
            }
        }
    }

    private void Syrge()
    {
        var willScript = grandparentObject.GetComponentInChildren<WillScript>();
        if (willScript != null)
        {
            rememberedWill = willScript.Will;
            willScript.Will = setwill;
            setwill = rememberedWill;
        }
    }
}
