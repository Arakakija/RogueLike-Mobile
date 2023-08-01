using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Normal Enemy")]
public class EnemyData : ScriptableObject
{
   [SerializeField] private int id;
   [SerializeField] private string enemyName;
   [SerializeField] private float hp;
   [SerializeField] private float damage;
   [SerializeField] private float speed;
   [SerializeField] private Sprite sprite;
   [SerializeField] private float scale;

   [SerializeField] private AnimationClip walkAnimation;
   [SerializeField] private AnimationClip deadAnimation;
   

   public int ID => id;
   public string Name => enemyName;
   public float HP => hp;
   public float Damage => damage;
   public float Speed => speed;
   public float Scale => scale;
   public Sprite Sprite => sprite;

   public AnimationClip WalkAnimation => walkAnimation;
   public AnimationClip DeadAnimation => deadAnimation;
   
}
