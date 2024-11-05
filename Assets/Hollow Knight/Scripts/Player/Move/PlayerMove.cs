using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerComponent
{
    protected enum MoveID
    {
        Stand, 
        Walk,
        Jump
    }

    [SerializeField] protected MoveID curMove;
    [SerializeField] protected Transform player;
    [SerializeField] protected Rigidbody2D playerRigid;
    [SerializeField] protected PlayerWalk walk;
    [SerializeField] protected PlayerJump jump;
    [SerializeField] protected float walkSpeed = 5f;
    [SerializeField] protected float jumpForce;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        player = transform.parent.parent;
        if (playerRigid == null) playerRigid = player.GetComponent<Rigidbody2D>();
    }

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        walk = LoadComponent<PlayerWalk>(walk, "Walk");
        jump = LoadComponent<PlayerJump>(jump, "Jump");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        curMove = MoveID.Stand;
        walkSpeed = 5f;
        jumpForce = 300f;
    }
    

    protected Vector3 GetDirection()
    {
        return InputManager.Instance.GetHorizontal();
    }
    protected void Walk(Vector3 direction)
    {
        playerRelayData.Anim.ChangeState("isWalk",false,true);
        walk.ExecuteWalk(player,direction,walkSpeed);
    }
    protected void Stand()
    {
        playerRelayData.Anim.ChangeState("isIdle", false,true);
    }

    protected void Jump()
    {
        playerRelayData.Anim.ChangeState("isJump",false,true);
        jump.Jump(playerRigid,jumpForce);
    }
    protected void ChangeMoveID(MoveID newMove)
    {
        curMove = newMove;
    }
    private void Update()
    {
        Vector3 direction = GetDirection();
        if(direction == Vector3.zero) Stand();
        else Walk(direction);
        if (InputManager.Instance.IsJump()) Jump();

    }
}
