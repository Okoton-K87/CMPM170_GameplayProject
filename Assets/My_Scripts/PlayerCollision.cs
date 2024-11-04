using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int damageFromEnemy = 10; // Damage the player takes when colliding with the enemy

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Deal damage to the player when colliding with an enemy
            HealthManager.Instance.DealDamage(gameObject, damageFromEnemy);
            Debug.Log("Player collided with enemy, taking damage.");
        }
    }
}
