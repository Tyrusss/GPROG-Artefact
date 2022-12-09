using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float health;
    public int goldValue;
    public Vector3 movementDir;
    public float speed;

    ObjectPooler objectPooler;

    [SerializeField]
    private bool _takingDamage;

    private readonly Vector3 SCREEN_CENTRE = new Vector3 ( 0.5f, 0.5f, 10f );

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

        transform.position = GetRandomSpawnPosition();
        SetMovementDirection();
        speed = Random.Range(1f, 4f);
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

        // If rock moves offscreen, kill it
        if (Vector3.Distance(Camera.main.WorldToViewportPoint(transform.position), SCREEN_CENTRE) >= 0.9f)
        {
            Die();
        }

        Move();
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime * movementDir;
    }

    Vector3 GetRandomSpawnPosition()
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

    void SetMovementDirection()
    {
        // Viewport coordinates are normalised between (0,0) (bottom left) and (1,1) (top right)
        Vector3 randomDestination = new Vector3(Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f), 10);
        randomDestination = Camera.main.ViewportToWorldPoint(randomDestination);

        movementDir = (randomDestination - transform.position).normalized;
    }

    void Die()
    {
        objectPooler.Remove(gameObject);
    }

}
