using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform greenBar;
    public RockController rockController;

    Vector3 greenBarSize;

    private void Awake()
    {
        greenBarSize = greenBar.localScale;
        greenBarSize.x = rockController.health;
    }

    private void Update()
    {
        greenBarSize.x = rockController.health;
        greenBar.localScale = greenBarSize;
    }
}
