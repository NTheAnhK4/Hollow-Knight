
using Core.Entity;
using UnityEngine;
using UnityEngine.Timeline;


public class PlayerController : EController
{
   
    [SerializeField] protected EMove move;
    [SerializeField] protected EAnim anim;
    [SerializeField] protected float jumpCount = 0;
    [SerializeField] protected bool onGround = true;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        if (move == null) move = GetComponentInChildren<EMove>();
        if (anim == null) anim = GetComponentInChildren<EAnim>();
    }

    private void Update()
    {
        if(InputManager.Instance.GetHorizontal() != Vector3.zero) Walk();
        else Stand();
        if(InputManager.Instance.IsJump()) Jump();
        if(InputManager.Instance.IsAttack()) Attack();
        move.ExecuteMove();
    }

    private void Stand()
    {
        if(onGround) anim.ChangeState("isIdle",true,false);
    }
    private void Walk()
    {
        move.SetMoveStrategy(new PlayerHorizontalMove());
        if (onGround) anim.ChangeState("isWalk",true,false);
    }
    private void Jump()
    {
        if (jumpCount >= 2)
        {
            anim.TurnPreState();
            return;
        }
        anim.ChangeState("preJump");
        anim.ChangeState("isJump",true,false);
        jumpCount++;
        onGround = false;
        move.SetMoveStrategy(new PlayerJump());
    }

    private void Attack()
    {
        anim.ChangeState("attack");
        anim.TurnPreState();
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
