using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * movementSpeed;
    }
}
