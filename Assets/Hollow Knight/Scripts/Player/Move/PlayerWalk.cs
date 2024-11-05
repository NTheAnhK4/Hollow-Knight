using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : ChildBehavior
{
    public void ExecuteWalk(Transform entity, Vector3 direction, float speed)
    {
        entity.Translate(direction *speed * Time.deltaTime);
    }
}
