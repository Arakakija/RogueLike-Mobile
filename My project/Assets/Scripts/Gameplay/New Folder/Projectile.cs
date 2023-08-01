using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _size;

    [SerializeField] private float dmg;
    [SerializeField] private Rigidbody2D rb;
    
    
    public void ShootProjectile(Vector3 enemyDirection)
    {
        enemyDirection.Normalize();
        rb.velocity = enemyDirection * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (!other.gameObject.CompareTag("Enemy") || !enemy.IsAlive) return;
        enemy.Health.onHitEvent?.Invoke(dmg);
        GameManager.Instance.BulletPooler.ReturnObjectToPool(this.gameObject);
    }
}
