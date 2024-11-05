using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerComponent
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float walkSpeed = 5f;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        player = transform.parent;
    }

    

    protected Vector3 GetDirection()
    {
        return InputManager.Instance.GetHorizontal();
    }
    protected void Walk(Vector3 direction)
    {
        playerRelayData.Anim.ChangeState("isWalk",false,true);
        player.transform.Translate(walkSpeed * direction * Time.deltaTime);
    }
    protected void Stand()
    {
        playerRelayData.Anim.ChangeState("isIdle", false,true);
    }
    private void Update()
    {
        Vector3 direction = GetDirection();
        if(direction == Vector3.zero) Stand();
        else Walk(direction);
    }
}
