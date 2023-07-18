using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Singleton<PlayerController>
{
    private TouchControlls _playerInput;
    [SerializeField] private PlayerCollisionController _collisionController;
    [SerializeField] private Health _health;
    [SerializeField] private RotateTowardsEnemy _rotateTowardsEnemy;
    [SerializeField] private PlayerAutoAim _playerAutoAim;
    [SerializeField] private float fireRate = 1.0f;

    private float fireRateTimer;

    public static Action Damaged;
    
    public TouchControlls Input => _playerInput;
    public PlayerCollisionController CollisionController => _collisionController;
    public Health Health => _health;
    public float FireRate => fireRate;


    protected override void Awake()
    {
        _playerInput = new TouchControlls();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        fireRateTimer += Time.deltaTime;
        if (_playerAutoAim.currentTarget)
        {
            Shoot();
        }
    }


    private bool CanShoot()
    {
        // Check if the fire rate timer exceeds the fire rate
        return fireRateTimer >= fireRate;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void Shoot()
    {
        if(!CanShoot()) return;
        Projectile projectile = GameManager.Instance.BulletPooler.SpawnObjectFromPool();
        _rotateTowardsEnemy.Rotate(_playerAutoAim.currentTarget.transform);
        Vector3 direction = _playerAutoAim.currentTarget.transform.position - transform.position;
        direction.Normalize();
        projectile.ShootProjectile(direction);
        ResetFireRateTimer();
    }
    
    private void ResetFireRateTimer()
    {
        // Reset the fire rate timer
        fireRateTimer = 0f;
    }



}
