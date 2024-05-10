using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTemple : MonoBehaviour
{
    // Start is called before the first frame update
    public float triggerXPosition; // The x position at which to trigger the scene transition

    void Update()
    {
        // Check if the player has passed the specified x position
        if (transform.position.x >= triggerXPosition)
        {
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

