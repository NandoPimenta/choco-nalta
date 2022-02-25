using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 5;

    public string triggerAttack = "Attack";

    public string BoolDeath= "Death";

    private Animator animator;

    public HealthBase health;

    public float timeToDestroy = 1f;

    private bool isAlive = true;    

    private void Awake()
    {
        if(health != null)
        {
            health.OnKill += OnEnemyKill;
        }
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<HealthBase>();

        if (playerHealth != null && isAlive)
        {
            PlayAttackAnimation();
            playerHealth.Damage(damage);
        }
    }


    


    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }


    public void Damage(int amount)
    {
        health.Damage(amount);
    }

    private void OnEnemyKill()
    {
        isAlive = false;
        health.OnKill -= OnEnemyKill;
        animator.SetTrigger(BoolDeath);
        Destroy(gameObject, timeToDestroy);

    }

}
