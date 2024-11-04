using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject objectToPool;   // The prefab to pool
    public int poolSize = 20;         // The size of the pool
    public bool expandable = true;    // Can we expand the pool if necessary?

    private List<GameObject> pool;    // List to store pooled objects

    void Start()
    {
        // Initialize the pool
        pool = new List<GameObject>();

        // Create the initial pool of objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false); // Deactivate the object
            pool.Add(obj);        // Add it to the pool
        }
    }

    // Method to retrieve an object from the pool
    public GameObject GetPooledObject()
    {
        // Find an inactive object in the pool
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // If no inactive objects are available and the pool is expandable, create a new one
        if (expandable)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pool.Add(obj);
            return obj;
        }

        // If no objects are available and pool is not expandable, return null
        return null;
    }
}
