using UnityEngine;

public class BatCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.CompareTag("bat"))
        {
            Debug.Log("Player collected a collectible.");

            // Notify the WinCon to increment the collectible count
            WinCon winCon = FindObjectOfType<WinCon>(); // Find WinCon in the scene
            if (winCon != null)
            {
                winCon.Collect();  // Increment the collectible count
            }

            // Add a delay before destroying to see if it gets to this point
            Debug.Log("Destroying bat now...");
            Destroy(other.gameObject, 0.1f);  // Delay destruction by 0.1 seconds
        }
    }
}
