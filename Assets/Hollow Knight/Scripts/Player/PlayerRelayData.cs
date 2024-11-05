using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRelayData : ParentBehavior
{
    [SerializeField] protected PlayerAnim anim;
    [SerializeField] protected PlayerMove move;

    public PlayerAnim Anim => anim;

    public PlayerMove Move => move;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        anim = LoadComponent<PlayerAnim>(anim, "Model");
        move = LoadComponent<PlayerMove>(move, "Move");
    }
}
