using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float laserWidth = 0.3f;
    public float maxLength = 28f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer.SetPositions(initLaserPositions);
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
