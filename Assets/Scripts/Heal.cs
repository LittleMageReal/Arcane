using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healAmount = 100;
    private Health health;
    [SerializeField] private int useCount = 3;
    [SerializeField] private float Cooldown = 2.5f;
    private float lastUse;

    void Start()
    {
        // Find the Health component in the scene
        health = GetComponentInParent<Health>();
    }

    private void Update()
    {
        
        
            if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUse >= Cooldown)
            {
                lastUse = Time.time;
                if (health != null)
                {
                    health.GainHealth(healAmount);
                }
                useCount--;
            }

            if (useCount <= 0) // If the object has been used three times
            {
                Destroy(gameObject); // Destroy the object
            }
        
    }
}
