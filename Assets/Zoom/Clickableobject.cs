using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Transform emptyObject;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Camera cameraToMove;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // check if the left mouse button is clicked
        {
            RaycastHit hit;
            Ray ray = cameraToMove.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Star")) // check if the object clicked has the "Star" tag
                {
                    // Move the camera to the empty object location
                    cameraTarget.position = emptyObject.position;

                    // Move the camera towards the target location
                    cameraToMove.transform.position = Vector3.MoveTowards(cameraToMove.transform.position, cameraTarget.position, moveSpeed * Time.deltaTime);
                }
            }
        }
    }
}