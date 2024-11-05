using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimState
{
    private Animator anim;
    private string stateName;

    public AnimState(Animator anim, string stateName)
    {
        this.anim = anim;
        this.stateName = stateName;
    }
    private void SetValue(object param)
    {
        if (stateName == String.Empty) return;
        switch (param)
        {
            case bool boolValue:
                anim.SetBool(stateName, boolValue);
                break;
            case int intValue:
                anim.SetInteger(stateName, intValue);
                break;
            case float floatValue:
                anim.SetFloat(stateName, floatValue);
                break;
            default:
                Debug.LogWarning("Unsupported parameter type: " + param.GetType());
                break;
        }
    }

    public void Enter(object param = null)
    {
        if(param == null) SetValue(true);
        else SetValue(param);
    }

    public void Exit(object param = null)
    {
        if(param == null)SetValue(false);
        else SetValue(param);
    }
}
