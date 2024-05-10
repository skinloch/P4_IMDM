using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float moveSpeed = 5f;  // How fast the spider moves
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = transform.forward;  // Initial movement direction
    }

    void FixedUpdate()
    {
        // Apply velocity in the direction the spider is currently facing
        rb.velocity = moveDirection * moveSpeed;

        // Keep the spider facing in the direction of its velocity
        transform.forward = moveDirection;

        // Update the animator with the speed
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reverse the movement direction upon collision with a wall
            moveDirection = -moveDirection;

            // Ensure spider faces the new direction, align transform forward to the new move direction
            transform.forward = moveDirection;
        }
    }
}
