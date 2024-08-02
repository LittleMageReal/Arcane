using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPunch : MonoBehaviour
{
    //Buff effect that give player or unit speed boost, when DashPunch is summoned 
    public float boostSpeed = 100f; // The speed boost
    public float duration = 1f; // The duration of the boost

    private void Start()
    {
        // Get all KArtController components in the scene
        KArtController kartController = GetComponentInParent<KArtController>();
        
        if (kartController != null)
        {
           StartCoroutine(Dash(kartController));
        }
    }

    //Coroutine to give unit speed boost
    private IEnumerator Dash(KArtController kartController)
    {
        // Save the original speed
        float originalSpeed = kartController._currentSpeed;

        // Increase the speed
        kartController._currentSpeed += boostSpeed;

        // Wait for the duration
        yield return new WaitForSeconds(duration);

        // Reset the speed
        kartController._currentSpeed = originalSpeed;

        // Destroy the dash effect object
        Destroy(gameObject);
    }
}
