using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{

    public Vector3 direaction;
    public float timeToDestroy = 2f;
    public float side = 1;

    public int damageAmount = 5;


    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direaction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }

}
