using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillScript : MonoBehaviour
{
    //WillScript for my units. Will work both as unit hit points and units damage 
    public int Will;
    public bool Rage = false; // Rage allow unit return some amount of will after been hit
    public int RageAmount;

    public bool illusion = false; // Units with illusion die on first hit

    public Health playerHealth; // Units with Crush deal damage to controlling player when destroed 
    public bool Crush = false; 
    public int CrushAmount;

    public bool Petrify = false; // Units with petrify return power when will drop to 0
    public int PetrifyAmount;

    private bool shouldDestroy = false;

    public bool Indesructable = false; // Unit dosent die when droped to 0

    void Start()
    {
        playerHealth = GetComponentInParent<Health>();
        if (playerHealth == null)
        {
            Debug.Log("Health script not found in parent.");
        }
    }

    void Update()
    {
        if (Will < 0)
        {
            if (Crush)
            {
                playerHealth.LoseHealth(CrushAmount);
            }

            if (Petrify)
            {
                PetrifyAmount -= 1;
                Will = 500;
                if (PetrifyAmount <= 0)
                {
                    Petrify = false;
                }
                
            }

            if (Indesructable)
            {
                Will = 0;
            }

            if ((gameObject != null) && !Petrify && !Indesructable)
            {
                shouldDestroy = true;
            }
        }

        if (shouldDestroy)
        {
            ScoreManager.Instance.AddPoints(100); // Use the ScoreManager to add points when unit died
             Destroy(gameObject);
        }

        Crush = false;
    }

    public void TakeDamage(int amount)
    {
        Will -= amount;
        RageCheck();
        if (illusion)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<WillScript>();
        if (atm != null)
        {
            atm.TakeDamage(Will);
        }
    }

    void RageCheck()
    {
        if (Rage == true)
        {
            Will += RageAmount;
        }
    }
}