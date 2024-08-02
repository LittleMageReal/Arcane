using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneShrink : MonoBehaviour
{
    //Zone Shrink script that deal damage when player outside of the zone and shrink down zone itself ( like battle royal, now not used in game )
    public int damageAmount = 10;
    public float damageInterval = 1f; // Time between each damage tick
    

    private void Start()
    {
        StartCoroutine(DealDamage()); // Start the damage coroutine
    }


    // Coroutine for dealing damage
    private IEnumerator DealDamage() 
    {
        while (true)
        {
            yield return new WaitForSeconds(damageInterval);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Find all players
            foreach (var player in players)
            {
                if (!IsInsideZone(player.transform.position)) //Deal damage to all players outside of zone
                {
                    // Get the Health component and call LoseHealth
                    var healthScript = player.GetComponent<Health>();
                    if (healthScript != null)
                    {
                        healthScript.LoseHealth(damageAmount);
                    }
                }
            }
        }
    }

    // Check if player inside of zone
    private bool IsInsideZone(Vector3 position)
    {
        return Vector3.Distance(position, transform.position) <= transform.localScale.x / 2;
    }
}
