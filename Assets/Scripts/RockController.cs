using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float health;
    public int goldValue;
    public Vector3 movementDir;

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

        transform.position = RandomPosition();
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


    Vector3 RandomPosition()
    {
        Vector3 startPos = new Vector3(0,0,10);

        // Viewport coordinates are normalised between (0,0) (bottom left) and (1,1) (top right)
        switch (Random.Range(1, 5)) // 1 = left, 2 = right, 3 = top, 4 = bottom
        {
            case 1:
                startPos.y = Random.Range(0f, 1f);

                startPos = Camera.main.ViewportToWorldPoint(startPos);
                startPos.x -= 1.5f;
                break;
            case 2:
                startPos.x = 1;
                startPos.y = Random.Range(0f, 1f);

                startPos = Camera.main.ViewportToWorldPoint(startPos);
                startPos.x += 1.5f;
                break;
            case 3:
                startPos.x = Random.Range(0f, 1f);
                startPos.y = 1;

                startPos = Camera.main.ViewportToWorldPoint(startPos);
                startPos.y += 1.5f;
                break;
            case 4:
                startPos.x = Random.Range(0f, 1f);

                startPos = Camera.main.ViewportToWorldPoint(startPos);
                startPos.y -= 1.5f;
                break;
        }

        return startPos;
    }

    void Die()
    {
        objectPooler.Remove(gameObject);
    }

}
