using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMove : EntityComponent
{
    public Transform player;
    [SerializeField] protected Transform entity;
    [SerializeField] protected TargetedMove targetMove;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        entity = transform.parent.parent;
    }

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        targetMove = LoadComponent<TargetedMove>(targetMove, "Target Move");
    }

    private void Update()
    {
        targetMove.Moving(entity, player, 1f);
    }
}
