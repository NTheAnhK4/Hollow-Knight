using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : ChildBehavior
{
    [SerializeField] protected PlayerRelayData playerRelayData;

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        if (playerRelayData == null) playerRelayData = transform.GetComponentInParent<PlayerRelayData>();
    }
}
