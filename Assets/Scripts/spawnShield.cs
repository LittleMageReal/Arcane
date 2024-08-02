using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnShield : MonoBehaviour
{
    //Shield obgect script 
    public GameObject ShieldPrefab;
    public Transform spawnPoint;
    [SerializeField] private int useCount = 3;
    private float Cooldown = 3f;
    private float lastUse;

    // Press q to summon a shield ( yeah i know better to make weapon activate script :c )
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUse >= Cooldown)
            {
                lastUse = Time.time;
                Invoke("Attack", 0.1f);  // waits for 0.4 seconds before calling Attack
                useCount--;
            } 
    }
     public void Attack()
     {
        GameObject ShieldInstance = Instantiate(ShieldPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        // Set the parent of the instantiated shield to the spawn point
        ShieldInstance.transform.SetParent(spawnPoint, true);

        // Optionally, reset the local position and rotation of the shield to ensure it's correctly positioned relative to the spawn point
        ShieldInstance.transform.localPosition = Vector3.zero;
        ShieldInstance.transform.localRotation = Quaternion.identity;

        StartCoroutine(DestroyAfterDelay(ShieldInstance, 3f));  // delay the destruction of attackInstance
     }

     // If the object has been used three times destroy the object
     private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
     {
        yield return new WaitForSeconds(3f);
        Destroy(obj);

        if (useCount <= 0) 
        {
            Destroy(gameObject); 
        }
     }


}
