using UnityEngine;

public class GreenOrb : MonoBehaviour
{
    public int healthRestorationAmount = 10; // Amount of health restored by the green orb

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the player's health script component
            HealthScript playerHealth = other.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                // Restore health to the player
                playerHealth.Heal(healthRestorationAmount);
                Debug.Log("Player picked up a green orb and gained " + healthRestorationAmount + " health.");

                // Destroy the orb after it's picked up
                Destroy(gameObject);
            }
        }
    }
}
