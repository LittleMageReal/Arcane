using UnityEngine;

public class Aiming : MonoBehaviour
{
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 directionToMouse = hit.point - transform.position;

            // Get the rotation that rotates from the current direction of the object to the direction of the hit point
            Quaternion rotation = Quaternion.LookRotation(directionToMouse, Vector3.up);

            // Apply the rotation to the object
            transform.rotation = rotation;

            // Remove rotation around the y-axis
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            eulerRotation.x = 0; // Zero out the y component
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    
    else
    {
        Debug.Log("ViewNotFound");
    }
  }
    
}


