using UnityEngine;

public class LootBox : MonoBehaviour
{
    public GameObject commonOrbPrefab;
    public GameObject rareOrbPrefab;
    public GameObject legendaryOrbPrefab;

    public int commonWeight = 60;
    public int rareWeight = 30;
    public int legendaryWeight = 10;

    private bool isDestroyed = false; // Prevents multiple hits

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile" && !isDestroyed)
        {
            isDestroyed = true;
            SpawnRandomOrb();
            DestroyLootBox(); // Destroy the loot box after being hit
        }
    }

    void SpawnRandomOrb()
    {
        // Use the weighted random system to determine which orb to spawn
        int randomValue = Random.Range(0, 100);
        GameObject orbToSpawn = null;

        if (randomValue < commonWeight)
        {
            orbToSpawn = commonOrbPrefab; // Common
        }
        else if (randomValue < commonWeight + rareWeight)
        {
            orbToSpawn = rareOrbPrefab; // Rare
        }
        else
        {
            orbToSpawn = legendaryOrbPrefab; // Legendary
        }

        if (orbToSpawn != null)
        {
            // Spawn the selected orb at the loot box's position
            Instantiate(orbToSpawn, transform.position, Quaternion.identity);
        }
    }

    void DestroyLootBox()
    {
        // Optionally, you can play a destruction animation or sound here before destroying the object
        Destroy(gameObject); // Destroy the loot box after spawning the orb
    }
}
