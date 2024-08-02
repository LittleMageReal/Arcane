using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KArtController : MonoBehaviour
{
    // KartController script that have all logic for kart controle. Functions called outside of scrip via input controller or ai input controller
    // Player controls sphere that main body follow for arcade controll

    //Kart constants
    [SerializeField] private Rigidbody sphereRb; //Sphere that player controll
    [SerializeField] private LayerMask groundLayerMask; // Ground Layer (now not used)
    private bool _isGrounded;

    //Drift Particles
    [SerializeField] private GameObject particleSystem1;
    [SerializeField] private GameObject particleSystem2;
    [SerializeField] private GameObject particleSystem3;

    //Nitro Particles
    [SerializeField] private GameObject greenParticleSystem;
    [SerializeField] private GameObject blueParticleSystem;
    [SerializeField] private GameObject redParticleSystem;

    //Drift manager refferens for point spend 
    public DriftPointManager SpecificDriftPointManager;

    // kart stats
    [SerializeField] private float forwardSpeed; 
    [SerializeField] private float turnSpeed;
    [SerializeField] private float backSpeed;
    public float _forwardAmount;
    public float _currentSpeed;
    public float _maxSpeed = 90;
    public float _turnAmount;
    
    //Kart status 
    public bool _isDrifting;
    private float _driftDirection;
    private float _driftTime;

    public bool shiftpresed;
    private float _redDriftCounter = 0f;
    public bool isSpeedBoostActive = false;
    
    public float speedBoostCooldown = 0f; 
    private float speedBoostCooldownDuration = 0f; 

    private Card.PointType lastPointTypeObtained = Card.PointType.Green; //Last obtaned point type for nitro
    
    //Find Sphere component
    private void Start()
    {
        sphereRb.transform.parent = null;
    }

    private void Update()
    {
      transform.position = sphereRb.transform.position;
    }
    
    // Activate speed boost to spend points on nitro. We spend last obtened type of points
    public void ActivateSpeedBoost()
    {
    if (!isSpeedBoostActive && speedBoostCooldown <= 0) // Ensure a speed boost is not already active
        {
            isSpeedBoostActive = true; // Set the flag to indicate a speed boost is active
            speedBoostCooldown = speedBoostCooldownDuration; // Reset the cooldown
            StartCoroutine(SpeedBoostCoroutine(lastPointTypeObtained));
        }
    }

 //Coroutine that spends point and Activate speedboost 
 private IEnumerator SpeedBoostCoroutine(Card.PointType pointTypeToSpend)
 {
    // Determine which particle system to activate based on the point type
    GameObject particleSystemToActivate = null;
    switch (pointTypeToSpend)
    {
        case Card.PointType.Green:
            particleSystemToActivate = greenParticleSystem;
            break;
        case Card.PointType.Blue:
            particleSystemToActivate = blueParticleSystem;
            break;
        case Card.PointType.Red:
            particleSystemToActivate = redParticleSystem;
            break;
    }

    // Activate the particle system locally
    if (particleSystemToActivate != null)
    {
        particleSystemToActivate.SetActive(true);
    }

    
   //Check is button held 
    while (shiftpresed)
    {
        // Check if there are enough points to spend
        if (SpecificDriftPointManager.SpendPoints(pointTypeToSpend, 1))
        {
            // Apply a temporary speed boost
            float originalSpeed = _currentSpeed;
            _currentSpeed *= 1.5f;
            yield return new WaitForSeconds(1); // Wait for 1 second before applying the boost again
            _currentSpeed = originalSpeed;
        }
        else
        {
            // Not enough points, deactivate the particle system and stop the coroutine
            if (particleSystemToActivate != null)
            {
                particleSystemToActivate.SetActive(false);
            }
            isSpeedBoostActive = false; // Reset the flag
            yield break;
        }
    }

    // Deactivate the particle system locally
    if (particleSystemToActivate != null)
    {
        particleSystemToActivate.SetActive(false);
    }

    
    isSpeedBoostActive = false; // Reset the flag when the Shift key is released
    speedBoostCooldown = speedBoostCooldownDuration; // Reset the cooldown
}

    // Rotate the sphere direction 
    public void TurnHandler()
    {
        float newRotation = _turnAmount * turnSpeed * Time.deltaTime;

        if (_currentSpeed > 0.1f) // Dosent rotate if standing in one place
            transform.Rotate(0, newRotation, 0, Space.World);
    }
    
    //Transform sphere position to drive and drift 
    private void FixedUpdate()
    {
        sphereRb.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);

        if (_isDrifting)
        {
            // Increase turn speed during drift
          float driftTurnSpeed = turnSpeed * 2; // Increase turnSpeed by a factor of 2 during drift
          float newRotation = _driftDirection * driftTurnSpeed * Time.deltaTime;
          transform.Rotate(0, newRotation, 0, Space.World);

          // Apply a stronger force to the vehicle in the direction of the drift
          Vector3 driftForce = -transform.right * _driftDirection * _currentSpeed /2;
          sphereRb.AddForce(driftForce, ForceMode.Acceleration);

          _driftTime += Time.deltaTime;
          // Start changing visual effects
          UpdateParticleSystems();

         // Start Gain Red points every second of long drift
         if (!isSpeedBoostActive && _driftTime > 2.7f)
           {
             _redDriftCounter += Time.deltaTime;
             if (_redDriftCounter >= 1f)
              {
                SpecificDriftPointManager.AddPoints(Card.PointType.Red);
                _redDriftCounter = 0f;
              }
           }

         //Change Drift direction if while drifting counter stear applied
           if (_isDrifting && Input.GetKey(KeyCode.Space) && _turnAmount != _driftDirection)
           {
             float counterForceMagnitude = _currentSpeed * 0.3f;
             Vector3 counterForce = transform.right * -_driftDirection * counterForceMagnitude;
             sphereRb.AddForce(counterForce, ForceMode.Acceleration);
           }
        }
    }

    // Acceleration 
    public void Drive()
    {
        if (_currentSpeed <= _maxSpeed)
            _currentSpeed += (_forwardAmount *= forwardSpeed) / 2;
        else
            _currentSpeed -= Time.deltaTime;
        _currentSpeed = Mathf.Max(_currentSpeed, backSpeed);
    }

    public void Stand()
    {
        _currentSpeed = 0;
    }


    public void StartDrift()
    {
        _isDrifting = true;
        _driftDirection = _turnAmount;
    }

    public void EndDrift()
    {
        _isDrifting = false;

        if (!isSpeedBoostActive && _driftTime > 2.7f)
        {
            SpecificDriftPointManager.AddPoints(Card.PointType.Red); // Gain points acording to the drift lenght, at the end of a drift 
            lastPointTypeObtained = Card.PointType.Red;
        }
        else if (!isSpeedBoostActive && _driftTime > 1.7f)
        {
            SpecificDriftPointManager.AddPoints(Card.PointType.Blue);
            SpecificDriftPointManager.AddPoints(Card.PointType.Blue);
            lastPointTypeObtained = Card.PointType.Blue;
        }
        else if (!isSpeedBoostActive && _driftTime > 0.3f)
        {
            SpecificDriftPointManager.AddPoints(Card.PointType.Green);
            lastPointTypeObtained = Card.PointType.Green;
        }

        _driftTime = 0;

        DeactivateParticleSystems(particleSystem1);
        DeactivateParticleSystems(particleSystem2);
        DeactivateParticleSystems(particleSystem3);

    }


    private void UpdateParticleSystems()
    {
        if (_driftTime > 2.7f)
        {
            ActivateParticleSystem(particleSystem3);
            DeactivateParticleSystems(particleSystem2);
        }
        else if (_driftTime > 1.7f)
        {
            ActivateParticleSystem(particleSystem2);
            DeactivateParticleSystems(particleSystem1);
        }
        else if (_driftTime > 0.3f)
        {
            ActivateParticleSystem(particleSystem1);
        }
    }

    private void ActivateParticleSystem(GameObject activeParticleSystem)
    {
        activeParticleSystem.SetActive(true);
    }

    private void DeactivateParticleSystems(GameObject activeParticleSystem)
    {
        activeParticleSystem.SetActive(false);
    }
}