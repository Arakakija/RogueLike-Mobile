using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    private ObjectPooler objectPool;
    public ObjectPooler Pool => objectPool;

    private Transform _playerTransform;
    
    [SerializeField] private float spawnRadius = 5f;
    [SerializeField] private float interval = 1.0f;

    private void Start()
    {
        objectPool = GetComponent<ObjectPooler>();
        _playerTransform = PlayerController.Instance.transform;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnObjectFromPool();

            // Wait for the specified spawn interval
            yield return new WaitForSeconds(interval);
        }
    }

    private void SpawnObjectFromPool()
    {
        Enemy obj = objectPool.GetObjectFromPool().GetComponent<Enemy>();
        // Customize and position the spawned object as needed
        obj.transform.position = SpawnObjectAroundPlayer();
        obj.SetData(GameManager.Instance.GetEnemyByIndex(0));
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        objectPool.ReturnObjectToPool(obj);
    }
    
    private Vector3 SpawnObjectAroundPlayer()
    {
        // Generate a random angle in radians
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate the spawn position based on the angle and spawn radius
        Vector3 spawnPosition = _playerTransform.position +
                                new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0f) * spawnRadius;

        return spawnPosition;
    }
}
