using UnityEngine;

public class CameraFlash : MonoBehaviour
{
    [SerializeField] private GameObject flashPanel; // Reference to the FlashPanel (UI Panel)
    [SerializeField] private GameObject flashHitboxPrefab; // The invisible hitbox prefab
    [SerializeField] private float stunDuration = 2f; // How long zombies are stunned
    [SerializeField] private float hitboxLifetime = 0.1f; // How long the hitbox exists
    [SerializeField] private float flashDisplayDuration = 0.2f; // How long the panel stays visible

    void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1)) // 1 = Right Mouse Button
        {
            Debug.Log("Right-click detected. Triggering flash.");
            TriggerFlash();
        }
    }

    void TriggerFlash()
    {
        // Show the flash panel
        if (flashPanel != null)
        {
            flashPanel.SetActive(true);
            Invoke(nameof(HideFlashPanel), flashDisplayDuration); // Hide the panel after the specified duration
        }

        // Instantiate the hitbox at the player's position
        GameObject flashHitbox = Instantiate(flashHitboxPrefab, transform.position, Quaternion.identity);

        // Pass the stun duration to the hitbox
        FlashHitbox hitboxScript = flashHitbox.GetComponent<FlashHitbox>();
        if (hitboxScript != null)
        {
            hitboxScript.Initialize(stunDuration);
            Debug.Log("Flash hitbox instantiated and initialized.");
        }

        // Destroy the hitbox after its lifetime
        Destroy(flashHitbox, hitboxLifetime);
        Debug.Log("Flash hitbox will be destroyed after " + hitboxLifetime + " seconds.");
    }

    void HideFlashPanel()
    {
        if (flashPanel != null)
        {
            flashPanel.SetActive(false);
            Debug.Log("Flash panel hidden.");
        }
    }
}
