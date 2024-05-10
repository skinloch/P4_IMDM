using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float moveSpeed = 5f;
    public float frequency = 1f;  // Speed of oscillation
    public float magnitude = 5f;  // Distance of oscillation
    private Vector3 startPos;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    void Update()
    {
        float move = Mathf.Sin(Time.time * frequency) * magnitude;
        transform.position = startPos + new Vector3(move, 0, 0);
        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, rb.velocity.z);

        // Update animation parameters
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
