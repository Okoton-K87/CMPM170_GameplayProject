using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;          // Speed of the projectile
    public float maxDistance = 50f;    // Maximum distance the projectile can travel before deactivating
    public int damage = 10;            // Damage dealt by the projectile

    private Vector3 startPosition;

    void OnEnable()
    {
        // Save the start position when the projectile is activated
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the projectile forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the projectile has traveled beyond the maximum distance
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            // Deactivate the projectile instead of destroying it
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy using the variable damage
            other.gameObject.GetComponent<HealthScript>()?.TakeDamage(damage);

            // Deactivate the projectile after hitting the enemy
            gameObject.SetActive(false);
        }
    }
}
