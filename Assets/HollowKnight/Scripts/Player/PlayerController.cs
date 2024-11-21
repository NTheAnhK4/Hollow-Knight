using System;
using System.Collections;
using System.Collections.Generic;
using Core.Entity;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : EController
{
    [SerializeField] protected EMove move;
    [SerializeField] protected float jumpCount = 0;
    [SerializeField] protected bool onGround = true;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        if (move == null) move = GetComponentInChildren<EMove>();
    }

    private void Update()
    {
        if(InputManager.Instance.GetHorizontal() != Vector3.zero) move.SetMoveStrategy(new PlayerHorizontalMove());
        if (InputManager.Instance.IsJump()) Jump();
        move.ExecuteMove();
    }

    private void Jump()
    {
        if (jumpCount >= 2)
        {
            move.SetMoveStrategy(new PlayerHorizontalMove());
            return;
        }
        jumpCount++;
        onGround = false;
        move.SetMoveStrategy(new PlayerJump());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            jumpCount = 0;
        }
    }
}
