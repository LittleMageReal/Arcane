using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillScript : MonoBehaviour
{
    public int Will;
    public bool Rage = false;
    public int RageAmount;

    public bool illusion = false;

    public Health playerHealth;
    public bool Crush = false;
    public int CrushAmount;

    public bool Petrify = false;
    public int PetrifyAmount;

    private bool shouldDestroy = false;

    public bool Indesructable = false;

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
            ScoreManager.Instance.AddPoints(100); // Use the GameManager to add points
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