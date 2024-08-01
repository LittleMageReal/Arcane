using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inputHandler : MonoBehaviour
{
    [SerializeField] private KArtController kartController;
    

    private void Update()
    {
        
        
        kartController._forwardAmount = Input.GetAxis("Vertical");
        kartController._turnAmount = Input.GetAxis("Horizontal");

            if (kartController._forwardAmount!= 0)
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
                kartController.shiftpresed = false;
            }

            if (kartController.speedBoostCooldown > 0)
            {
                kartController.speedBoostCooldown -= Time.deltaTime;
            }
        
    }
}
