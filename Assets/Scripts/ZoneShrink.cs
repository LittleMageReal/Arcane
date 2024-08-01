using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneShrink : MonoBehaviour
{

    public int damageAmount = 10;
    public float damageInterval = 1f; // Time between each damage tick
    

    private void Start()
    {
        StartCoroutine(DealDamage()); // Start the damage coroutine
    }


    private IEnumerator DealDamage() // New coroutine for dealing damage
    {
        while (true)
        {
            yield return new WaitForSeconds(damageInterval);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Find all players
            foreach (var player in players)
            {
                if (!IsInsideZone(player.transform.position))
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

    private bool IsInsideZone(Vector3 position)
    {
        return Vector3.Distance(position, transform.position) <= transform.localScale.x / 2;
    }
}
