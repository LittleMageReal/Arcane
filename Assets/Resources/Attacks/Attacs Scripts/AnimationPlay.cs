using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    //Animation system to animate attacks 
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // trigered via button press, need to change
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Trigger the attack animation
        animator.SetTrigger("Attack");
    }
}
