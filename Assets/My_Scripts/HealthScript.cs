using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 200;
    private int currentHealth;
    private ScoreManager scoreManager;

    [SerializeField] private GameObject lootBoxPrefab; // Reference to the loot box prefab

    private float healthDrainTimer = 0f; // Timer for health drain

    void Start()
    {
        // Set starting health from GameSettings if available
        maxHealth = GameSettings.playerStartingHealth > 0 ? GameSettings.playerStartingHealth : maxHealth;
        currentHealth = maxHealth;

        // Find ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        // Gradually decrease health over time
        GradualHealthDrain();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " takes " + damage + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Player healed by " + amount + " health. Current health: " + currentHealth);
    }

    public void HealToMax()
    {
        currentHealth = maxHealth;
        Debug.Log("Player's health fully restored. Current health: " + currentHealth);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died.");

        if (CompareTag("Player"))
        {
            // Load Game Over scene if the player dies
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // Award points if this is an enemy and ScoreManager is present
            if (scoreManager != null)
            {
                scoreManager.AddScore(100);
            }

            // Ensure loot box is assigned, and spawn loot boxes
            if (lootBoxPrefab != null)
            {
                SpawnLootBoxes();
            }
            else
            {
                Debug.LogWarning("Loot box prefab is not assigned in the Inspector.");
            }

            // Destroy the enemy
            Destroy(gameObject);
        }
    }

    void SpawnLootBoxes()
    {
        // Determine a random number of loot boxes to spawn (1-3)
        int lootCount = Random.Range(1, 4);
        Debug.Log("Spawning " + lootCount + " loot box(es).");

        for (int i = 0; i < lootCount; i++)
        {
            // Set spawn position 2 units above the enemy's position, with a slight random offset to avoid overlap
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 2f, Random.Range(-0.5f, 0.5f));
            GameObject loot = Instantiate(lootBoxPrefab, spawnPosition, Quaternion.identity);

            // Check if loot was successfully instantiated
            if (loot != null)
            {
                Debug.Log("Loot box spawned successfully at " + spawnPosition);
            }
            else
            {
                Debug.LogError("Failed to spawn loot box.");
            }
        }
    }

    void GradualHealthDrain()
    {
        // Increment the timer
        healthDrainTimer += Time.deltaTime;

        // Reduce health by 1 every second
        if (healthDrainTimer >= 1f)
        {
            TakeDamage(1);
            healthDrainTimer = 0f;
        }
    }
}
