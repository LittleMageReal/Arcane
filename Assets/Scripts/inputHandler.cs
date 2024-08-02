using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour
{
    [SerializeField] private KArtController kartController;
    
   // Player Input script to send signals in KArtController script
    private void Update()
    {
        
        kartController._forwardAmount = Input.GetAxis("Vertical");
        kartController._turnAmount = Input.GetAxis("Horizontal");

            if (kartController._forwardAmount!= 0) //change kart behavior
                kartController.Drive();
            else
                kartController.Stand();

            kartController.TurnHandler();

            if (Input.GetButtonDown("Jump") &&!kartController._isDrifting && Mathf.Abs(kartController._turnAmount) >= 0.5)
                kartController.StartDrift();

            if (kartController._isDrifting && (Input.GetButtonUp("Jump") || (Input.GetKeyUp(KeyCode.W))))
                kartController.EndDrift();

            if (Input.GetKeyDown(KeyCode.LeftShift) &&!kartController.isSpeedBoostActive)
            {
                kartController.shiftpresed = true;
                kartController.ActivateSpeedBoost();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                kartController.shiftpresed = false;//Stop drift when key up
            }

            if (kartController.speedBoostCooldown > 0)
            {
                kartController.speedBoostCooldown -= Time.deltaTime;
            }
        
    }
}
