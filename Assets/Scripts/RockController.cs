using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float health;

    [SerializeField]
    private bool _takingDamage = false;

    public bool TakingDamage
    {
        get
        {
            return _takingDamage;
        }
        set
        {
            _takingDamage = value;
        }
    }

    private void Awake()
    {
        health = 1;
    }

    private void Update()
    {
        if (_takingDamage)
        {
            // lose 50% per second
            health -= 0.5f * Time.deltaTime;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //placeholder for pooling
        Destroy(gameObject);
    }

}
