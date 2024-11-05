using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityComponent : ChildBehavior
{
    [SerializeField] protected EntityDataRelay dataRelay;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        if (dataRelay == null) dataRelay = transform.GetComponentInParent<EntityDataRelay>();
    }
}
