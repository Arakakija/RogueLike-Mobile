using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private EnemyPooler _enemyPooler;
    [SerializeField] private BulletPool _bulletPool;

    public EnemyPooler EnemyPooler => _enemyPooler;

    public BulletPool BulletPooler => _bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
