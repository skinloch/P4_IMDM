using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoulderHit : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI loseText; // Assign your TextMeshPro UI element in the inspector
    public GameObject playerMovement; // Assign the player GameObject or the component controlling movement

    private void Start()
    {
        // Ensure the lose text is not visible at the start
        loseText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the boulder
        if (collision.gameObject.tag == "Boulder")
        {
            // Display the "You Lose" message
            loseText.text = "You Lose";
            loseText.gameObject.SetActive(true);

            // Disable the player's movement script(s)
            if (playerMovement.GetComponent<BasicBehaviour>() != null)
            {
                playerMovement.GetComponent<BasicBehaviour>().enabled = false;
            }
            if (playerMovement.GetComponent<MoveBehaviour>() != null)
            {
                playerMovement.GetComponent<MoveBehaviour>().enabled = false;
            }

            // Optional: Stop the boulder's movement by setting its velocity to zero
            Rigidbody boulderRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (boulderRigidbody != null)
            {
                boulderRigidbody.velocity = Vector3.zero;
                boulderRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}
