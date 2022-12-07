using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float health;

    ObjectPooler objectPooler;

    [SerializeField]
    private bool _takingDamage;

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
        objectPooler = GameObject.FindGameObjectWithTag("Object Pooler").GetComponent<ObjectPooler>();
    }

    private void OnEnable()
    {
        _takingDamage = false;
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
        objectPooler.Remove(gameObject);
    }

}
