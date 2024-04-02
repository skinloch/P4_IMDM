using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCamera; // Assign in the inspector
    public GameObject followCamera; // Assign in the inspector
    public TextMeshProUGUI interactText; // Assign your TextMeshPro UI element in the inspector
    public Transform gemTransform; // Assign the gem's transform in the inspector
    public GameObject player; // Assign the player GameObject in the inspector
    public float interactionDistance = 2f; // Distance within which the interaction prompt appears
    public Rigidbody boulderRigidbody;
    private bool isInteractable = false; // To check if within interactable distance
    private BasicBehaviour playerBasicBehaviour;
    private MoveBehaviour playerMoveBehaviour;

    private void Start()
    {
        // Initialize
        mainCamera.SetActive(true);
        followCamera.SetActive(false);
        interactText.gameObject.SetActive(false); // Hide the text initially

        // Attempt to get the player's behaviour scripts
        playerBasicBehaviour = player.GetComponent<BasicBehaviour>();
        playerMoveBehaviour = player.GetComponent<MoveBehaviour>();

        // Initially disable the player's movement and behaviour scripts
        if (playerBasicBehaviour != null) playerBasicBehaviour.enabled = false;
        if (playerMoveBehaviour != null) playerMoveBehaviour.enabled = false;
    }

    private void Update()
    {
        // Check the distance between the camera/player and the gem
        float distance = Vector3.Distance(transform.position, gemTransform.position);

        // If within interaction distance and not already interactable
        if (distance <= interactionDistance && !isInteractable)
        {
            isInteractable = true;
            interactText.gameObject.SetActive(true);
            interactText.text = "Press E to interact with the gem.";
        }
        else if (distance > interactionDistance && isInteractable) // If outside interaction distance
        {
            isInteractable = false;
            interactText.gameObject.SetActive(false);
        }

        
        // If within interactable distance and "E" is pressed
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            // Perform your interaction logic here (e.g., switch cameras)
            mainCamera.SetActive(false);
            followCamera.SetActive(true);
            interactText.gameObject.SetActive(false); // Optionally, hide the text after interaction
            isInteractable = false; // Prevent further interaction

            // Enable the player's movement and behaviour scripts
            if (playerBasicBehaviour != null) playerBasicBehaviour.enabled = true;
            if (playerMoveBehaviour != null) playerMoveBehaviour.enabled = true;
            if (boulderRigidbody != null)
    {
        boulderRigidbody.useGravity = true;
        boulderRigidbody.isKinematic = false; // Ensure it's not kinematic to allow for physics simulation
    }
        }
    }
}
