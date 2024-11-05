using UnityEngine;

public class PurpleOrb : MonoBehaviour
{
    public float speedBoostAmount = 10f; // Amount of speed boost
    public float boostDuration = 5f;     // Duration of the speed boost in seconds

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the player's movement script component
            RigidbodyMovement playerMovement = other.GetComponent<RigidbodyMovement>();
            if (playerMovement != null)
            {
                // Start the speed boost coroutine
                playerMovement.StartCoroutine(playerMovement.SpeedBoost(speedBoostAmount, boostDuration));
                Debug.Log("Player picked up a purple orb and gained a speed boost of " + speedBoostAmount + " for " + boostDuration + " seconds.");

                // Destroy the orb after it's picked up
                Destroy(gameObject);
            }
        }
    }
}
