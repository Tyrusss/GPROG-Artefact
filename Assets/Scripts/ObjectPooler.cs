using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] pool;

    private float timer;
    private float currentTime = 0f;
    public GameObject newRock;

    public GameObject Create()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeSelf == false)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        return null;
    }

    public void Remove(GameObject obj)
    {
        for (int i = 0; i< pool.Length; i++)
        {
            if (pool[i] == obj)
            {
                pool[i].SetActive(false);
                return;
            }
        }

        Debug.Log("Obj not found in pool");
    }

    private void Awake()
    {
        timer = Random.Range(0.5f, 4f); // Spawns rock at random intervals between 0.5 and 4 seconds
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer)
        {
            newRock = Create();
            currentTime = 0;

            timer = Random.Range(0.5f, 4f);
        }
    }
}
