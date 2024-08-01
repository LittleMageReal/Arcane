using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoTower : MonoBehaviour
{
    public GameObject attackPrefab;
    public WillScript willScript;
    public float speed = 10f;
    public float distance = 10f;
    public Transform prefabPosition;
    [SerializeField] Transform target = null; 

    void Start()
    {
        
        
        
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;

                Vector3 direction = (target.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
            }
        
        
        
          StartCoroutine(MoveAndInstantiatePrefab());
        
    }

    IEnumerator MoveAndInstantiatePrefab()
    {
        // Move the object forward
        float elapsedDistance = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedDistance < distance)
        {
            elapsedDistance += speed * Time.deltaTime;

            // Move the unit forward
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

            yield return null;
        }


        GameObject attackInstance = Instantiate(attackPrefab, prefabPosition.position, Quaternion.Euler(0, 0, 0));

        Damage damage = attackInstance.GetComponent<Damage>();
        StartCoroutine(DestroyAfterDelay(gameObject, 0.3f));

        IEnumerator DestroyAfterDelay(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }
    }
}
