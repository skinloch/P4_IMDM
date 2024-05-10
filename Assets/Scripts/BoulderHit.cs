using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BoulderHit : MonoBehaviour
{
    public TextMeshProUGUI loseText;
    public GameObject playerMovement;
    public float restartDelay = 5f;

    private void Start()
    {
        loseText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boulder")
        {
            loseText.text = "You Lose!\nRestarting in " + restartDelay + "...";
            loseText.gameObject.SetActive(true);

            if (playerMovement.GetComponent<BasicBehaviour>() != null)
            {
                playerMovement.GetComponent<BasicBehaviour>().enabled = false;
            }
            if (playerMovement.GetComponent<MoveBehaviour>() != null)
            {
                playerMovement.GetComponent<MoveBehaviour>().enabled = false;
            }

            Rigidbody boulderRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (boulderRigidbody != null)
            {
                boulderRigidbody.velocity = Vector3.zero;
                boulderRigidbody.angularVelocity = Vector3.zero;
            }

            StartCoroutine(RestartSceneAfterDelay(restartDelay));
        }
    }

    private IEnumerator RestartSceneAfterDelay(float delay)
    {
        float count = delay;
        while (count > 0)
        {
            loseText.text = "You Lose!\nRestarting in " + count + "...";
            yield return new WaitForSeconds(1);
            count--;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
