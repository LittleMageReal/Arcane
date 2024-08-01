using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawn : MonoBehaviour
{
    public GameObject SKelly;
    public Transform[] spawnPoints; // Array to hold spawn point transforms
    public float maxOffsetDistance = 5f; // Maximum distance for random offset

    void Start()
    {
       SpawnRandomSkellyWithOffset();
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnRandomSkellyWithOffset();
        }
    }

    void SpawnRandomSkellyWithOffset()
    {
        if (spawnPoints.Length > 0)
        {
            Transform selectedSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

            // Calculate random offset within the defined range
            Vector3 randomOffset = new Vector3(
                UnityEngine.Random.Range(-maxOffsetDistance, maxOffsetDistance),
                0, // Assuming no vertical offset for simplicity
                UnityEngine.Random.Range(-maxOffsetDistance, maxOffsetDistance)
            );

            // Apply offset to spawn point's position
            Vector3 finalSpawnPosition = selectedSpawnPoint.position + randomOffset;

            // Instantiate SKelly at the final spawn position with the spawn point's rotation
            GameObject spawnedSkelly = Instantiate(SKelly, finalSpawnPosition, selectedSpawnPoint.rotation);
            spawnedSkelly.transform.SetParent(selectedSpawnPoint.transform);
        }
        else
        {
            Debug.LogError("No spawn points defined.");
        }
    }
}
