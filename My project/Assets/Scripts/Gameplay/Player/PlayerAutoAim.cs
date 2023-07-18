using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
    private Transform referencePoint;

    private List<GameObject> Enemies;
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
    

    private GameObject FindNearestObject()
    {
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject obj in  Enemies = GameManager.Instance.EnemyPooler.Pool.objectPool)
        {
            // Calculate the distance between the reference point and the object
            float distance = Vector3.Distance(referencePoint.position, obj.transform.position);

            // If the current distance is smaller than the previous nearest distance, update the nearest object and distance
            if (distance < nearestDistance)
            {
                nearestObject = obj;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }
}
