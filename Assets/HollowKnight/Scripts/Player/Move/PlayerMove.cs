
using Core.Entity;

using UnityEngine;

public class PlayerMove : EMove
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 50f;
    
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        if(entity == null) entity = transform.parent;
        if (rb == null) rb = transform.GetComponentInParent<Rigidbody2D>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 5f;
        this.jumpForce = 5f;
    }

    public override void SetMoveStrategy(IMoveStrategy newStrategy)
    {
        base.SetMoveStrategy(newStrategy);
        if (newStrategy is PlayerJump) this.speed = jumpForce;
        else this.speed = moveSpeed;
    }

    public override void ExecuteMove(Transform target = null)
    {
        this.moveStrategy?.Move(entity,target,speed,rb);
    }

    
}
