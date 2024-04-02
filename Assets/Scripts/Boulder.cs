using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private bool isActive = false;
    public float speed = 5f; // You can adjust the rolling speed
    private Transform playerTransform; // To store player's position

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
    }

    public void Activate()
    {
        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            // Move the sphere in a straight line towards the player's last position
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}

