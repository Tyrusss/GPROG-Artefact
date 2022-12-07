using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] pool;

    private float timer = 2f;
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

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer)
        {
            newRock = Create();
            currentTime = 0;
        }
    }
}
