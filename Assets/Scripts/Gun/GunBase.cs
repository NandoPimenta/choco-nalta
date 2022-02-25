using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{

    public BulletBase prefabBullet;
    public Transform positionToShoot;
    public float timeBetweenShoot = .05f;

    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }



    private void Shoot()
    {
        var bullet = Instantiate(prefabBullet);
        
        bullet.transform.position = positionToShoot.position;
        bullet.side = playerSideReference.transform.localScale.x;
        

    }


    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
}
