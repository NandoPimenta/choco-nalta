using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{

    public Vector3 direaction;
    public float time = 2f;
    public float side = 1;
    public int damageAmount = 5;

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(timeToReset());
            transform.Translate(direaction * Time.deltaTime * side);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy != null)
        {
            enemy.Damage(damageAmount);
            gameObject.SetActive(false);
        }
    }
    
      IEnumerator timeToReset()
    {
        
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        
    }
    

}
