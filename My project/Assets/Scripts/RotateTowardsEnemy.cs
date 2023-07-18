using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsEnemy : MonoBehaviour
{
    public void Rotate(Transform enemy)
    {
        if (enemy)
        {
            Vector3 direction = enemy.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
