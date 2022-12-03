using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float defaultSpeed;
    public float defaultRotateSpeedRad;

    public GameObject laserOrigin;
    public Vector3 mousePos;

    public RaycastHit2D rayHit;
    public Vector3 rayHitPoint;

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

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = defaultSpeed;
        rotateSpeedRad = defaultRotateSpeedRad;
        mousePos = Vector3.zero;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = defaultSpeed;
        rotateSpeedRad = defaultRotateSpeedRad;

        mousePos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

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
        if (angleOfRotationRad > 2 * Mathf.PI) { angleOfRotationRad -= 2 * Mathf.PI; }
        if (angleOfRotationRad < 0) { angleOfRotationRad += 2 * Mathf.PI; }
        angleOfRotationDeg = angleOfRotationRad * Mathf.Rad2Deg;
        newRotationEulers.z = angleOfRotationDeg;
        transform.eulerAngles = newRotationEulers;

        // Movement
        newPos.x = transform.position.x + (Mathf.Cos(angleOfRotationRad) * currentSpeed * Time.deltaTime);
        newPos.y = transform.position.y + (Mathf.Sin(angleOfRotationRad) * currentSpeed * Time.deltaTime);
        transform.position = newPos;

        // Laser
        if (Input.GetKey(KeyCode.Space))
        {
            rayHit = Physics2D.Raycast(laserOrigin.transform.position, laserOrigin.transform.right);
            if (rayHit.collider != null)
            {
                rayHitPoint = rayHit.point;
                Debug.Log(rayHit.collider.gameObject.name);
            }
        }
    }
}
