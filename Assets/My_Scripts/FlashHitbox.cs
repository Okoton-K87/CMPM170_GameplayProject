using UnityEngine;

public class FlashHitbox : MonoBehaviour
{
    private float stunDuration;

    public void Initialize(float duration)
    {
        stunDuration = duration;
        Debug.Log("FlashHitbox initialized with stun duration: " + stunDuration + " seconds.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an enemy
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Flash hitbox collided with: " + other.gameObject.name);

            // Get the NavMeshAgent component and reduce its speed
            UnityEngine.AI.NavMeshAgent agent = other.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent != null)
            {
                Debug.Log("Enemy " + other.gameObject.name + " stunned for " + stunDuration + " seconds.");
                StartCoroutine(StunEnemy(agent, other.gameObject));
            }
        }
    }

    private System.Collections.IEnumerator StunEnemy(UnityEngine.AI.NavMeshAgent agent, GameObject enemy)
    {
        float originalSpeed = agent.speed; // Save the original speed
        agent.speed = 0f; // Set the speed to 0 to "stun" the enemy

        // Find the MarioQuestionBlock child and enable it
        Transform questionBlock = enemy.transform.Find("MarioQuestionBlock");
        if (questionBlock != null)
        {
            questionBlock.gameObject.SetActive(true); // Activate the child object
            Debug.Log("MarioQuestionBlock activated for " + enemy.name);
        }

        yield return new WaitForSeconds(stunDuration); // Wait for the stun duration

        agent.speed = originalSpeed; // Restore the original speed
        Debug.Log("Enemy " + agent.gameObject.name + " stun duration ended. Speed restored to " + originalSpeed + ".");

        // Disable the MarioQuestionBlock again
        if (questionBlock != null)
        {
            questionBlock.gameObject.SetActive(false); // Deactivate the child object
            Debug.Log("MarioQuestionBlock deactivated for " + enemy.name);
        }
    }
}
