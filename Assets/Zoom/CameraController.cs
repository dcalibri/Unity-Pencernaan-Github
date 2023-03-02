using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Vector3 targetOffset;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float fieldOfView = 60f;
    [SerializeField] private bool isActivated = false;
    [SerializeField] private float timerDuration = 2f; // Duration of the timer in seconds

    private Camera cam;
    private Transform cameraPosition;
    private float timer = 0f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        cameraPosition = transform;

        if (Input.GetMouseButtonDown(0)) // check if the left mouse button is clicked
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ClickableObject")) // check if the object clicked has the "ClickableObject" tag
                {
                    // Move the camera to the new location
                    cameraTarget.position = hit.point + targetOffset;
                    cameraPosition.position = cameraTarget.position;
                    cam.fieldOfView = fieldOfView;

                    // Rotate the camera to face the new direction
                    Vector3 targetDir = cameraTarget.position - transform.position;
                    float step = rotationSpeed * Time.deltaTime;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
            }
        }

        // Move the camera towards the target location
        transform.position = Vector3.MoveTowards(transform.position, cameraPosition.position, moveSpeed * Time.deltaTime);

        if (isActivated)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if the timer has expired
            if (timer >= timerDuration)
            {
                // Deactivate the boolean and reset the timer
                isActivated = false;
                timer = 0f;
            }
        }
    }

    private void Update()
    {
        if (!isActivated)
        {
            // Check for left mouse button click
            if (Input.GetMouseButtonDown(0))
            {
                // Set the timer to active
                isActivated = true;
            }
        }
    }
}