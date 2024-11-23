using System.Collections;
using System.Collections.Generic;
using Core.Entity;
using UnityEngine;

public class EnemyAnim : EAnim
{
    protected override void OnEnable()
    {
        base.OnEnable();
        curStateAnim = new EStateAnim(anim, "isIdle", true, false);
        preStateAnim = curStateAnim;
    }
}
