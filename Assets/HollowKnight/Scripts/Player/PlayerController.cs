
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
        if (onGround)
        {
            if (InputManager.Instance.IsJump())
            {
                anim.ChangeState("preJump");
                anim.ChangeState("isJump",true,false);
                jumpCount++;
                onGround = false;
                move.SetMoveStrategy(new PlayerJump());
                move.ExecuteMove();
                if (InputManager.Instance.GetHorizontal() != Vector3.zero)
                {
                    move.SetMoveStrategy(new PlayerHorizontalMove()); 
                    move.ExecuteMove();
                }
            }
            else
            {
                if (InputManager.Instance.GetHorizontal() != Vector3.zero)
                {
                    anim.ChangeState("isWalk",true,false);
                    move.SetMoveStrategy(new PlayerHorizontalMove());
                    move.ExecuteMove();
                }
                else
                {
                    anim.ChangeState("isIdle",true,false);
                    move.SetMoveStrategy(new PlayerStand());
                    move.ExecuteMove();
                }
            }
        }
        else
        {
            if (InputManager.Instance.IsJump())
            {
                if (jumpCount >= 2)
                {
                    move.SetMoveStrategy(new PlayerStand());
                    anim.ChangeState("isFall", true, false);
                    move.ExecuteMove();
                }
                else
                {
                    jumpCount++;
                    move.SetMoveStrategy(new PlayerJump());
                    move.ExecuteMove();
                }
            }

            if (InputManager.Instance.GetHorizontal() != Vector3.zero)
            {
                move.SetMoveStrategy(new PlayerHorizontalMove());
                move.ExecuteMove();
            }
        }

        if (InputManager.Instance.IsAttack())
        {
            anim.ChangeState("attack");
            anim.TurnPreState();
        }
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
