using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
   //Script to make ai bot that will follow targets, drift and use speed boost  
[SerializeField] private List<Transform> targetPositionsList; // List of target positions

public Transform player;
private int currentTargetIndex = 0; // Current target index
public float arrivalThreshold = 1f; // Distance threshold for considering arrival
public KArtController kartController; // Reference to the KArtController script
public Vector3 targetPosition; // Target player's transform

void Start()
{ 
   player = GameObject.FindGameObjectWithTag("Player").transform;
   targetPositionsList.Add(player);
}

void Update()
{
 //Find and set target 
 SetTargetPosition(targetPositionsList[currentTargetIndex].position);

 //Input send by bot
 float forwardAmount = 0f;
 float turnAmount = 0f;

 //Calculate is target in front or behind 
 float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
 Vector3 DirectionToMove = (targetPosition - transform.position).normalized;
 float dot = Vector3.Dot(transform.forward, DirectionToMove);
 if (dot > 0) // if target in front move forward 
 {
  forwardAmount = 1f;
 }
 else 
 {
   //if target to far behind turn around via going in front
   float reverseDistance = 25f;
   if (distanceToTarget > reverseDistance){
      forwardAmount = 1f;
   }
   else {
      forwardAmount = -1f; // if target close move backward
   }
 }

 // calculate is target in left or in right 
 float AngleToTarget = Vector3.SignedAngle(transform.forward, DirectionToMove, Vector3.up);
 if (AngleToTarget > 0) // turn right
 {
  turnAmount = 1f;
 }
 else  // turn left
  {
   turnAmount = -1f;
  }

 float driftangle = Mathf.Abs(AngleToTarget); // if target far left or far right, start drift
  if (driftangle > 40)
 { 
   kartController.StartDrift();
 }
 else 
 {
   kartController.EndDrift();
 }

if (driftangle < 5)  // if target in front, use speed boost 
{
   kartController.shiftpresed = true;
   kartController.ActivateSpeedBoost();
 }
 else 
 {
   kartController.shiftpresed = false;
 }
 // Activate controll functions of KArtcontroller after all calculations 
 kartController._forwardAmount = forwardAmount;
 kartController._turnAmount = turnAmount;
 kartController.Drive();
 kartController.TurnHandler();

}
public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        ChangeTarget();
        if (currentTargetIndex >= targetPositionsList.Count) // Loop back to the first target
        {
            currentTargetIndex = 0;
        }
    }

public void ChangeTarget() //if target reached change target 
{
   float distanceToCurrentTarget = Vector3.Distance(transform.position, targetPosition);
    if (distanceToCurrentTarget <= arrivalThreshold)
    {
     currentTargetIndex++; // Move to the next target
    }
}
}