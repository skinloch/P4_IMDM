using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionOnPosition : MonoBehaviour
{
    public Vector3 targetPosition; // The target position to trigger the scene switch
    public float distanceThreshold = 1f; // How close the player needs to be to the target position

    void Update()
    {
        // Check if the player is within the distance threshold of the target position
        if (Vector3.Distance(transform.position, targetPosition) <= distanceThreshold)
        {
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
