using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // The player's transform
    public Vector3 offset; // Offset from the player
    public float smoothSpeed = 0.125f; // How smoothly the camera catches up with its target position

    void Start()
    {
        // Calculate the initial offset based on current positions
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optional: Make the camera always look at the player
        // transform.LookAt(playerTransform);
    }
}
