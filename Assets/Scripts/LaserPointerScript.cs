using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour
{
    public float laserWidth;
    public float maxLength;
    public GameObject PlayerCharacter;

    [Header("Serialized fields")]
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Vector3[] newPositions;
    private Vector3[] defaultPositions;
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Vector3 startPoint = Vector3.zero;
    [SerializeField]
    private Vector3 endPoint;
    private Vector3 defaultEndPoint;

    private Vector3 mousePos;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerController = PlayerCharacter.GetComponent<PlayerController>();

        defaultEndPoint = new Vector3(maxLength, 0, 0);
        defaultPositions = new Vector3[2] { startPoint, defaultEndPoint };

        lineRenderer.SetPositions(newPositions);
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
    }

    // Update is called once per frame
    void Update()
    {
        endPoint = defaultEndPoint;
        newPositions = defaultPositions;

        mousePos = playerController.mousePos;

        if (lineRenderer.enabled)
        {
            lineRenderer.enabled = false;
        }

        if (playerController.rayHit.collider != null)
        {
            endPoint = transform.InverseTransformPoint(playerController.rayHitPoint);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            newPositions[1] = endPoint;
            lineRenderer.SetPositions(newPositions);
            lineRenderer.enabled = true;
        }
        RotateLaserPointer();
    }
    void RotateLaserPointer()
    {
        // Set world space rotation in direction of mouse pointer
        angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), 0.3f);

        // Clamp localRotation to only look forward
        float localAngle = transform.localRotation.eulerAngles.z;
        if (localAngle > 60 && localAngle < 180) { transform.localRotation = Quaternion.Euler(0, 0, 60); }
        if (localAngle < 300 && localAngle > 180) { transform.localRotation = Quaternion.Euler(0, 0, 300); }
    }

}
