using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
    private Transform referencePoint;

    private List<GameObject> Enemies;

    [SerializeField] private float searchRadius = 5.0f;
    public GameObject currentTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        referencePoint = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
       currentTarget = FindNearestObject();
    }
    

    // ReSharper disable Unity.PerformanceAnalysis
    private GameObject FindNearestObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(referencePoint.position, searchRadius);

        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;

        foreach (Collider2D collider in colliders)
        {
            var enemy = collider.gameObject.GetComponent<Enemy>();
            // Check if the collider belongs to a game object that you want to consider (e.g., by tag or layer)
            if (enemy && enemy.IsAlive)
            {
                Transform objectTransform = collider.transform;
                float distanceToTarget = Vector2.Distance(referencePoint.position, objectTransform.position);

                // Check if the current object is closer than the previously closest one
                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestObject = objectTransform;
                }
            }
        }

        return closestObject == null ? null : closestObject.gameObject;
    }
}
