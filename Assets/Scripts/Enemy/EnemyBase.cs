using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 5;

    public string triggerAttack = "Attack";

    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        var health = collision.GetComponent<HealthBase>();
        
        if(health != null)
        {
            PlayAttackAnimation();
            health.Damage(damage);
        }
    }


    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

}
