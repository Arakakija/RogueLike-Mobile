using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float invincibilityDuration = 0.5f;
    
    public bool isInvincible = false;
    private Vector3 knockbackDirection;

    private void Update()
    {
        if (isInvincible)
        {
            transform.position += knockbackDirection * (knockbackForce * Time.deltaTime);
        }
    }

    public void ApplyKnockback(Vector2 direction)
    {
        if (!isInvincible)
        {
            StartCoroutine(KnockbackRoutine(direction));
        }
    }
    
        
    public void ApplyKnockback(Vector2 direction,float AdditionalForce)
    {
        if (!isInvincible)
        {
            StartCoroutine(KnockbackRoutine(direction, AdditionalForce));
        }
    }

    private IEnumerator KnockbackRoutine(Vector2 direction)
    {
        isInvincible = true;
        knockbackDirection = direction.normalized;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private IEnumerator KnockbackRoutine(Vector2 direction, float AdditionalForce)
    {
        isInvincible = true;
        knockbackDirection = direction.normalized * AdditionalForce;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}
