using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaKnockback : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private float maxDistance = 5f;
    [Range(1.0f, 10.0f)]
    [SerializeField] private float AdditionalForce = 1.5f;

    private void Update()
    {

    }

    public void KnockbackArea()
    {
        // Perform a circle raycast
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, maxDistance);

        // Process the raycast results
        foreach (RaycastHit2D hit in hits)
        {
            if(this.gameObject == hit.collider.gameObject) continue;

            if (hit.collider.CompareTag("Enemy"))
            {
                Vector2 direction = hit.transform.position - transform.position;
                hit.collider.GetComponent<Knockback>().ApplyKnockback(direction,AdditionalForce);
            }
        }
    }
    
}
