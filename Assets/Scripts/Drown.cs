using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drown : MonoBehaviour
{
    //Script for field effect drown. Drown send current unit to bottom of a deck( actually now it just destroy it)
    public float shrinkTime = 1f; // Time in seconds for the object to shrink

    // Check if collided unit have any children at spawnpoint and destroy them
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a "SpawnPoint" child
        Transform spawnPoint = other.transform.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            foreach (Transform child in spawnPoint)
            {
                Destroy(child.gameObject);
                // Start shrinking the object that this script is attached to
                StartCoroutine(ShrinkAndDestroy(this.gameObject));
            }
        }
    }
    
    // Shrink animation
    IEnumerator ShrinkAndDestroy(GameObject target)
    {
        float elapsedTime = 0f;

        while (elapsedTime < shrinkTime)
        {
            // Calculate the new scale
            Vector3 newScale = Vector3.Lerp(target.transform.localScale, Vector3.zero, elapsedTime / shrinkTime);

            // Apply the new scale
            target.transform.localScale = newScale;

            // Wait for the next frame
            yield return null;

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;
        }
        // Destroy the object
        Destroy(target);
    }
}