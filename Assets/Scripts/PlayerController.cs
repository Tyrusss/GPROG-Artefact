using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float defaultSpeed;
    public float defaultRotateSpeedRad;

    [Header("Serialized fields")]
    [SerializeField]
    private Vector3 newPos;
    [SerializeField]
    private Vector3 newRotationEulers; // degrees
    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private float angleOfRotationRad; // radians
    [SerializeField]
    private float angleOfRotationDeg; // radians
    [SerializeField]
    private float rotateSpeedRad; // radians


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = defaultSpeed;
        rotateSpeedRad = defaultRotateSpeedRad;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = defaultSpeed;
        rotateSpeedRad = defaultRotateSpeedRad;

        if (Input.GetKey(KeyCode.W))
        {
            // Speed up and slow turning speed
            currentSpeed += 2f;
            rotateSpeedRad -= 1.5f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Slow down
            currentSpeed -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate counter-clockwise
            angleOfRotationRad += rotateSpeedRad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Rotate clockwise
            angleOfRotationRad -= rotateSpeedRad * Time.deltaTime;
        }

        // Rotation
        angleOfRotationDeg = angleOfRotationRad * Mathf.Rad2Deg;
        newRotationEulers.z = angleOfRotationDeg;
        transform.rotation = Quaternion.Euler(newRotationEulers);

        // Movement
        newPos.x = transform.position.x + (Mathf.Cos(angleOfRotationRad) * currentSpeed * Time.deltaTime);
        newPos.y = transform.position.y + (Mathf.Sin(angleOfRotationRad) * currentSpeed * Time.deltaTime);
        transform.position = newPos;
    }

}
