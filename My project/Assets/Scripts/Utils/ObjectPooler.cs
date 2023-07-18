using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize = 10;

    public List<GameObject> objectPool;
    
    private void Start()
    {
        objectPool = new List<GameObject>(initialPoolSize);

        // Instantiate and populate the object pool
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        // Search for an inactive object in the pool and return it
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // If no inactive object is found, create a new one and add it to the pool
        GameObject newObj = Instantiate(prefab, transform);
        objectPool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}