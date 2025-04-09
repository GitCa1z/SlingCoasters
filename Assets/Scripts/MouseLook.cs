using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;    // The player body
    public float rotationSpeed = 5f; // Speed at which the player rotates towards the mouse position

    void Update()
    {
        RotatePlayerToMouse();
    }

    void RotatePlayerToMouse()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPos = Input.mousePosition;

        // Create a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);

        // Raycast to find where the ray intersects the ground 
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Get the hit point on the ground 
            Vector3 targetPosition = hit.point;

            // Calculate the direction from the player to the target 
            Vector3 direction = targetPosition - playerBody.position;

            // Keep the rotation only on the Y axis (horizontal rotation)
            direction.y = 0f;

            // If the direction is not too small, rotate the player towards the target
            if (direction.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                playerBody.rotation = Quaternion.Slerp(playerBody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

}
