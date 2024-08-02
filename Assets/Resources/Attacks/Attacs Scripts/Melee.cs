using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    // Melee close attack script ( I think for it we can use just shoot script, and by logic of bullet itself)
    public GameObject attackPrefab;
    public Transform spawnPoint;
    public WillScript willScript;
    public float attackRange = 1.0f;
    [SerializeField] private float Cooldown = 2f;
    private float lastUse;
    

    void Update()
    {
     if (Input.GetButtonDown("Fire1") && Time.time - lastUse >= Cooldown)
        {
           lastUse = Time.time;
           Invoke("Attack", 0.4f);  // waits for 1 second before calling Attack
        }
    }

    // just spawn damage prefab
    public void Attack()
    {
        GameObject attackInstance = Instantiate(attackPrefab, spawnPoint.position, spawnPoint.rotation);
        attackInstance.transform.SetParent(spawnPoint);

        Damage number = attackInstance.GetComponent<Damage>(); //damage calculator
        number.damageAmount = willScript.Will;

        Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, attackRange);
        foreach (Collider collider in colliders)
        {
            WillScript targetWillScript = collider.GetComponent<WillScript>();
            if (targetWillScript != null )
            {
                continue; // Ignore units that have the same owner as the attacking unit
            }

            // Apply damage to the target unit
            targetWillScript?.TakeDamage(willScript.Will);
        }

        Destroy(attackInstance, 0.3f);  // destroys the game object after 1 second
    }

}