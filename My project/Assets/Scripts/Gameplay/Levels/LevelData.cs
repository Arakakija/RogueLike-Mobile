using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private EnemyData[] enemies;
    //TODO: Map data

    public EnemyData[] Enemies => enemies;
}
