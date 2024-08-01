using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    public GameObject WaterPrefab;
    public GameObject refreshtide;
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(refreshtide, transform.position, Quaternion.Euler(0, 90, 0));
    }
}
