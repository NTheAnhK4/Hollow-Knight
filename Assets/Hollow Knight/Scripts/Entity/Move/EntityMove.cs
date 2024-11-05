using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMove : EntityComponent
{
    [SerializeField] protected Transform player;
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

    protected void IsPlayerVisible()
    {
        player = null;
        object virtualPlayer = dataRelay.Sensor.IsPlayerVisible();
        if (virtualPlayer is Transform realPlayer) player = realPlayer;
    }
    private void Update()
    {
        IsPlayerVisible();
        if (player == null) return;
        targetMove.Moving(entity, player, 1f);
    }
}
