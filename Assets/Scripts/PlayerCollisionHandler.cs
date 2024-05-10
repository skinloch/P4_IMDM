using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  
using System.Collections;  

public class PlayerCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI loseAndCountdownText; 
    public GameObject playerMovement; 
    private bool isPlayerActive = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spider") && isPlayerActive)
        {
            isPlayerActive = false;
            loseAndCountdownText.text = "You Lose!\nRestarting in 5..."; 
            loseAndCountdownText.gameObject.SetActive(true);

            DisablePlayerMovement();
            StopPlayerMovement();
            StartCoroutine(RestartCountdown(5)); 
        }
    }

    private void DisablePlayerMovement()
    {
        // Disable BasicBehaviour if it exists
        BasicBehaviour basicBehaviour = playerMovement.GetComponent<BasicBehaviour>();
        if (basicBehaviour != null)
        {
            basicBehaviour.enabled = false;
        }

        // Disable MoveBehaviour if it exists
        MoveBehaviour moveBehaviour = playerMovement.GetComponent<MoveBehaviour>();
        if (moveBehaviour != null)
        {
            moveBehaviour.enabled = false;
        }
    }

    private void StopPlayerMovement()
    {
        // Zero out the Rigidbody's velocity and angular velocity
        Rigidbody rb = playerMovement.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private IEnumerator RestartCountdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            loseAndCountdownText.text = "You Lose!\nRestarting in " + count.ToString() + "...";
            yield return new WaitForSeconds(1);
            count--;
        }
        RestartScene();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
