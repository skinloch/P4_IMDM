using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject sphere; // Assign this in the inspector with your sphere GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem") // Make sure your gem has the tag "Gem"
        {
            Destroy(other.gameObject); // Remove the gem from the scene
            sphere.GetComponent<SphereScript>().Activate(); // Activate the sphere
        }
    }
}