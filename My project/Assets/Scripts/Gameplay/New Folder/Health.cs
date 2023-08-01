using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHp = 100.0f;
    [SerializeField] private float maxHP = 100.0f;

    public  UnityAction<float> onHitEvent;
    public  UnityAction<float> onHealEvent;
    public UnityAction onDead;

    public float CurrentHealth => currentHp;
    public float MaxHP => maxHP;

    private void OnEnable()
    {
        onHitEvent += GetHit;
        onHealEvent += GetHeal;
    }

    private void OnDisable()
    {
        onHitEvent -= GetHit;
        onHealEvent -= GetHeal;
    }

    void Start()
    {
        currentHp = maxHP;
    }

    public void SetHp(float hp)
    {
        maxHP = hp;
        currentHp = maxHP;
    }
    
    void GetHit(float damage)
    {
        currentHp -= damage;
        if (!(currentHp <= 0)) return;
        onDead?.Invoke();
    }

    void GetHeal(float healthAmount)
    {
        if(currentHp >= maxHP) return;
        currentHp += healthAmount;
    }

    
    
}
