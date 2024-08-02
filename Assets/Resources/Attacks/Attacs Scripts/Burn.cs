using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    // Deal damage on collision. 
    public int damageAmount = 100;
    private void Start()
    {
       // StartCoroutine(DestroyAfterDelay()); //Turned of for now, because used as death wall for falls 
    }
    void OnTriggerEnter(Collider other)
    {
        var healthScript = other.gameObject.GetComponent<Health>();
        if (healthScript != null)
        {
            healthScript.LoseHealth(damageAmount);
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
