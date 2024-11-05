using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : ChildBehavior
{
    [SerializeField] protected PlayerRelayData playerRelayData;

    public void LoadDataRelay(PlayerRelayData relayData)
    {
        this.playerRelayData = relayData;
    }
}
