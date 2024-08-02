using UnityEngine;

public class Damage : MonoBehaviour
{
    //Script to deal damage to units and players . Old script
    public int damageAmount = 10; // Set this to the amount of damage you want the bullet to do
    public bool Punish; // deal double damage to opponent when attack directly (work as bug, better make just x2)
    [SerializeField] private float DestroctionTime = 0.1f;
    [SerializeField] private bool Destroeble;
    [SerializeField] private bool isDestroyed;
   
   
    //deal damage on collision. If punish true tregger two times 
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