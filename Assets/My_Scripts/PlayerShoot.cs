using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootingPoint;       // The point from where projectiles are shot
    public ObjectPooler projectilePooler; // Reference to the ObjectPooler script

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Get a pooled projectile object
        GameObject projectile = projectilePooler.GetPooledObject();

        if (projectile != null)
        {
            // Set the projectile's position and rotation
            projectile.transform.position = shootingPoint.position;
            projectile.transform.rotation = shootingPoint.rotation;

            // Activate the projectile
            projectile.SetActive(true);
        }
    }
}
