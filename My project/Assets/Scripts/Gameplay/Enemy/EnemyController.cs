using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private Rigidbody2D _rb;
    [SerializeField] private Health _health;
    [SerializeField] private Knockback _knockbackComponent;
    [SerializeField] public float damage = 10; //TODO: Change to enemy real stat

    public Health Health => _health;

    private void OnEnable()
    {
        _health.onDead += Die;
    }

    private void OnDisable()
    {
        _health.onDead -= Die;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!_rb)_rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;

        // Normalize the direction vector to get a unit vector
        direction.Normalize();

        // Calculate the movement amount based on the speed and time
        float movementAmount = speed * Time.deltaTime;

        // Move the object towards the target
        transform.position += direction * movementAmount;
    }

    void Die()
    {
        GameManager.Instance.EnemyPooler.ReturnObjectToPool(this.gameObject);
    }
    
}
