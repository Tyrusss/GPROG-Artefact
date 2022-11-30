using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour
{
    public float laserWidth;
    public float maxLength = 28f;

    private Vector3[] newPositions;
    private LineRenderer lineRenderer;
    private Vector3 startPoint = Vector3.zero;
    private Vector3 endPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        newPositions = new Vector3[2] { startPoint, endPoint };

        lineRenderer.SetPositions(newPositions);
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
    }

    // Update is called once per frame
    void Update()
    {
        endPoint = startPoint;

        if (Input.GetKey(KeyCode.Space))
        {
            endPoint.x += maxLength;
        }

        newPositions[0] = startPoint;
        newPositions[1] = endPoint;
        lineRenderer.SetPositions(newPositions);
    }
}
