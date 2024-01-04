using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10;
    public bool destroyonkill = false;

    public float delayonKill = 0f;


    public float _currentLife;
    private bool _isDead = false;

    private void Awake()
    {
        Init(); 
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;

    }

    public void Damage(int damage)
    {
        if (_isDead) return;


        _currentLife -= damage;
        if(_currentLife <=0)
        {
            kill();
        }
    }

    private void kill()
    {
        _isDead = true;

        if(destroyonkill)
        {
            Destroy(gameObject, delayonKill);
        }
    }

}
