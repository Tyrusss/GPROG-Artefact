using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform greenBar;
    public RockController rockController;

    Vector3 greenBarSize;

    private void Start()
    {
        greenBarSize = greenBar.localScale;
    }

    private void Update()
    {
        greenBarSize.x = rockController.health;
        greenBar.localScale = greenBarSize;
    }
}
