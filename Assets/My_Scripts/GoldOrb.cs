using UnityEngine;

public class GoldOrb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the player's health script component
            HealthScript playerHealth = other.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                // Set player's health to max
                playerHealth.HealToMax();
                Debug.Log("Player picked up a gold orb and restored to full health.");

                // Destroy the orb after it's picked up
                Destroy(gameObject);
            }
        }
    }
}
