using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;


    private int _currentLife;
    private bool _isDead = false;

    [SerializeField]
    private FlashColor _flashColor;
    void Awake()
    {
        init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();       
        }
    }

    private void init()
    {
        _isDead = false;
        _currentLife = startLife;
    }


    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }


    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject);
        }
    }
}
