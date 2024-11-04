using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 200;
    private int currentHealth;
    private ScoreManager scoreManager;

    void Start()
    {
        // Set starting health from GameSettings if available
        maxHealth = GameSettings.playerStartingHealth > 0 ? GameSettings.playerStartingHealth : maxHealth;
        currentHealth = maxHealth;

        // Find ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
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

            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
