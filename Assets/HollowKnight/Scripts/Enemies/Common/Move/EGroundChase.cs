using System.Collections;
using System.Collections.Generic;
using Core.Entity;
using UnityEngine;

public class EGroundChase : IMoveStrategy
{
    private Vector3 direction = Vector3.left;
    
    public void Move(Transform entity, Transform target = null, float speed = 0, Rigidbody2D rb = default)
    {
        if (entity.position.x < -3) direction = Vector3.right;
        if (entity.position.x > 3) direction = Vector3.left;
        entity.Translate(direction * speed * Time.deltaTime);
    }
}
