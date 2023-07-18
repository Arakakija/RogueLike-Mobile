using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private ObjectPooler objectPool;
    public ObjectPooler Pool => objectPool;
    [SerializeField]private Transform spawnPosition;

    private void Start()
    {
        objectPool = GetComponent<ObjectPooler>();
    }
    
    public Projectile SpawnObjectFromPool()
    {
        GameObject obj = objectPool.GetObjectFromPool();
        // Customize and position the spawned object as needed
        obj.transform.position = spawnPosition.position;
        return obj.GetComponent<Projectile>();
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        objectPool.ReturnObjectToPool(obj);
    }
    
}
