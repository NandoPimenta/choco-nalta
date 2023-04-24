using System;
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

    public int numberPollingBullet = 20;
    private List<BulletBase> pollingBullet;
    
    private void Awake()
    {
        StartPool();
    }

    private void StartPool()
    {
        pollingBullet = new List<BulletBase>();

        for (int i = 0; i < numberPollingBullet; i++)
        {
            var bullet = Instantiate(prefabBullet);
            bullet.gameObject.SetActive(false);
            pollingBullet.Add(bullet);
        }
        
    }    
    
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
        for (int i = 0; i < numberPollingBullet; i++)
        {
            if (!pollingBullet[i].gameObject.activeInHierarchy)
            {
                pollingBullet[i].gameObject.transform.position = positionToShoot.position;
                pollingBullet[i].side = playerSideReference.transform.localScale.x;
                pollingBullet[i].gameObject.SetActive(true);
                break;
            }
        }
        

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
