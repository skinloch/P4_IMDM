using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float collisionRadius = 0.5f;

    private Vector3 originalPosition;

    private void Start()
    {
        // Record the original position of the camera
        originalPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the desired movement direction based on keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the camera forward or backward
        transform.position += transform.forward * moveDirection.z * moveSpeed * Time.deltaTime;

        // Ensure the camera doesn't move below its original position
        float newPositionY = Mathf.Max(transform.position.y, originalPosition.y);
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);

    }
}
