using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Knockback _knockbackComponent;
    [SerializeField] private AreaKnockback _areaKnockback;
    

    // Start is called before the first frame update
    void Start()
    {
        if(!_rb)_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !_knockbackComponent.isInvincible)
        {
            float damage = other.gameObject.GetComponent<EnemyController>().damage;
            PlayerController.Instance.Health.onHitEvent?.Invoke(damage);
            Vector2 direction = transform.position - other.transform.position; 
            _knockbackComponent.ApplyKnockback(direction);
            _areaKnockback.KnockbackArea();
        }
    }
}
