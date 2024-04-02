using UnityEngine;

public class BoulderMovement : MonoBehaviour
{
    public Transform target; // Assign the player's transform
    public float speed = 5f; // Adjust speed as necessary

    private bool isActive = false;

    public void Activate()
    {
        isActive = true;
    }

    void Update()
    {
        if (!isActive) return;

        // Move the boulder towards the target
        Vector3 step = speed * Time.deltaTime * Vector3.Normalize(target.position - transform.position);
        step.y = 0; // Optional: Keep the boulder moving horizontally
        transform.position += step;
    }
}

