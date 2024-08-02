using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAndDebuffManager : MonoBehaviour
{
    //Manager to spawn buffs and debuffs 
    public GameObject freezePrefab;
    
    public void SpawnFreezePrefab()
    {
        Instantiate(freezePrefab, transform);
    }
}
