using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
        }
    }

}
