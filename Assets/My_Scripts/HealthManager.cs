using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Singleton instance of HealthManager for easy access
    public static HealthManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure there is only one instance of HealthManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Function to apply damage to any entity with HealthScript
    public void DealDamage(GameObject target, int damage)
    {
        HealthScript healthScript = target.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.TakeDamage(damage);
            Debug.Log(target.name + " took " + damage + " damage.");
        }
        else
        {
            Debug.LogWarning("No HealthScript found on " + target.name);
        }
    }
}
