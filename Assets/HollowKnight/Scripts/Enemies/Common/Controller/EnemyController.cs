
using Core.Entity;
using UnityEngine;

public class EntityController : EController
{
    [SerializeField] protected EMove move;
    [SerializeField] protected EAnim anim;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        if (move == null) move = GetComponentInChildren<EMove>();
        if (anim == null) anim = GetComponentInChildren<EAnim>();
    }

    private void Update()
    {
        anim.ChangeState("isWalk",true,false);
        move.ExecuteMove();
    }
}
