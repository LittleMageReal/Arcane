using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damageAmount = 10; // Set this to the amount of damage you want the bullet to do
    public bool Punish;
    [SerializeField] private float DestroctionTime = 0.1f;
    [SerializeField] private bool Destroeble;
    [SerializeField] private bool isDestroyed;
   
   
    void OnCollisionEnter(Collision collision)
    {
        var willScript = collision.gameObject.GetComponent<WillScript>();
        if (willScript != null)
        {
            willScript.TakeDamage(damageAmount);
        }

        if (Punish == true)
        {
            var health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.LoseHealth(damageAmount);
            }
        }
        if ( Destroeble == true)
        {
            Invoke("DestroyBullet", DestroctionTime);
        }
        
    }
     void DestroyBullet()
     {
        
        
            if (!isDestroyed && gameObject != null)
            {
                Destroy(gameObject);
                isDestroyed = true;
            }
        
        
    }

    
    public void SetDamage(int damage)
    {
        damageAmount = damage;
    }
}