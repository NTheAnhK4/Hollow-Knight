using UnityEngine;
using System.Collections.Generic;
public class EntityDetection
{
    private Transform entity;
    private float radius;
    private BoxCollider2D boxCollider2D;

    public EntityDetection(Transform entity, float radius, BoxCollider2D boxCollider2D)
    {
        this.entity = entity;
        this.radius = radius;
        this.boxCollider2D = boxCollider2D;
    }
    public List<Transform> DetectObjects()
    {
        List<Transform> detectedObjects = new List<Transform>();
        Collider2D[] objectInRange = Physics2D.OverlapCircleAll(entity.position, radius);
        foreach (var obj in objectInRange)
        {
            if (CanSeeObject(obj))
                detectedObjects.Add(obj.transform);
        }
        return detectedObjects;
    }

    private bool CanSeeObject(Collider2D obj)
    {
        Vector3 entityPosition = entity.position;
        Vector3 objectPosition = obj.transform.position;
        Vector2 direction = (objectPosition - entityPosition).normalized;
        boxCollider2D.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(entityPosition, direction, radius);
        boxCollider2D.enabled = true;
        return (hit.collider != null && hit.collider == obj);
    }

}