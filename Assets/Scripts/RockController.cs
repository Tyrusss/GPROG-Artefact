using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float health;
    public int goldValue;

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
		goldValue = Random.Range(1, 4); // gives the player a random amount of gold between 1 and 3 inclusive when mined
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
            ResourceTracker.Gold += goldValue;
            Die();
        }
    }

    void Die()
    {
        objectPooler.Remove(gameObject);
    }

}
