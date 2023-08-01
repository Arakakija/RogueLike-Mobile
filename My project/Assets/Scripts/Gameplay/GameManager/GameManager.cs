using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private EnemyPooler _enemyPooler;
    [SerializeField] private BulletPool _bulletPool;

    [SerializeField] private LevelData levelData;
    

    public EnemyPooler EnemyPooler => _enemyPooler;

    public BulletPool BulletPooler => _bulletPool;
    public LevelData Level => levelData;

    public EnemyData GetEnemyByIndex(int index)
    {
        return levelData.Enemies[index];
    }

    public EnemyData GetEnemyByID(int enemyID)
    {
        return levelData.Enemies.First((enemy) => enemy.ID == enemyID);
    }

    public EnemyData GetEnemyByName(string name)
    {
        return levelData.Enemies.First((enemy) => enemy.Name.ToLower() == name.ToLower());
    }
    
}
