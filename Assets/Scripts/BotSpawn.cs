using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawn : MonoBehaviour
{
    // Sctipt to spawn objects in scene near spawn point at random position
    public GameObject Token; //object to spawn
    public Transform[] spawnPoints; // Array to hold spawn point transforms
    public float maxOffsetDistance = 5f; // Maximum distance for random offset

    void Start()
    {
       SpawnRandomTokenWithOffset();
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // spawn manualy 
        {
            SpawnRandomTokenWithOffset();
        }
    }

    void SpawnRandomTokenWithOffset()
    {
        if (spawnPoints.Length > 0)
        {
            // Select random position to spawn in
            Transform selectedSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

            // Calculate random offset within the defined range
            Vector3 randomOffset = new Vector3
            (
                UnityEngine.Random.Range(-maxOffsetDistance, maxOffsetDistance),
                0, //  no vertical offset
                UnityEngine.Random.Range(-maxOffsetDistance, maxOffsetDistance)
            );

            // Apply offset to spawn point's position
            Vector3 finalSpawnPosition = selectedSpawnPoint.position + randomOffset;

            // Instantiate Token at the final spawn position with the spawn point's rotation
            GameObject spawnedToken = Instantiate(Token, finalSpawnPosition, selectedSpawnPoint.rotation);
            spawnedToken.transform.SetParent(selectedSpawnPoint.transform);
        }
        else
        {
            Debug.LogError("No spawn points defined.");
        }
    }
}
