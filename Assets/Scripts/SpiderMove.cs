using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float changeInterval = 2f; // Time between direction changes
    public float forceStrength = 10f; // Strength of the force
    private Rigidbody rb;
    private float nextChangeTime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextChangeTime = Time.time + changeInterval;
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextChangeTime)
        {
            nextChangeTime += changeInterval;
            ApplyForce();
        }
    }

    void ApplyForce()
    {
        // Reverse the force direction
        rb.velocity = Vector3.zero; // Reset velocity to prevent speed build-up
        rb.AddForce(new Vector3(forceStrength, 0, 0) * (Time.time % (changeInterval * 2) < changeInterval ? 1 : -1), ForceMode.VelocityChange);
    }
}
