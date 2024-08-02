using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    // Heal bottle script that heal player when used 
    public int healAmount = 100;
    private Health health; //health script
    [SerializeField] private int useCount = 3; //amount of uses
    [SerializeField] private float Cooldown = 2.5f; 
    private float lastUse; // Last time use for cooldown

    void Start()
    {
       // Find the Health component in parent object 
       health = GetComponentInParent<Health>();
    }

    private void Update()
    {
        // When player press q gain health 
      if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUse >= Cooldown)
         {
            lastUse = Time.time;

            if (health != null)
              {
                 health.GainHealth(healAmount);
              }

             useCount--;
         }
        // If the object has been used three times destroy it 
        if (useCount <= 0) 
         {
            Destroy(gameObject); 
         } 
    }
}
