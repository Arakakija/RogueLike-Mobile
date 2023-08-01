using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private EnemyData data;
    private Rigidbody2D _rb;
    [SerializeField] private Health _health;
    [SerializeField] private Knockback _knockbackComponent;
    [SerializeField] private Sprite _sprite;

    private EnemyAnimator _enemyAnimator;


    public Health Health => _health;
    public EnemyData Data => data;

    public void SetData(EnemyData data)
    {
        this.data = data;
    }

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
        _enemyAnimator = GetComponent<EnemyAnimator>();
        if(!_rb)_rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").gameObject.transform;
        _health.SetHp(data.HP);
        transform.localScale *= data.Scale;
        _sprite = data.Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;

        // Normalize the direction vector to get a unit vector
        direction.Normalize();

        // Calculate the movement amount based on the speed and time
        float movementAmount = data.Speed * Time.deltaTime;

        // Move the object towards the target
        transform.position += direction * movementAmount;
    }

    void Die()
    {
       _enemyAnimator.PlayAnimationByTrigger("Dead");
       StartCoroutine(WaitForAnimationToEnd());
    }
    

    private IEnumerator WaitForAnimationToEnd()
    {
        // Wait until the animation is no longer playing
        while (_enemyAnimator.IsAnimationPlaying("Dead"))
        {
            Debug.Log("Entro");
            yield return null;
        }

        // The animation has ended, execute additional code here
        GameManager.Instance.EnemyPooler.ReturnObjectToPool(this.gameObject);
    }
    
}
