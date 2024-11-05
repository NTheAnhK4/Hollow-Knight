using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedMove : ChildBehavior
{
    public void Moving(Transform entity, Transform target, float speed)
    {
        float distance = Vector2.Distance(target.position, entity.position);
        if (Mathf.Abs(distance) < 1f) return;
        Vector3 direction = (target.position - entity.position).normalized;
        entity.Translate(direction * speed * Time.deltaTime);
    }
}
