using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector3 GetHorizontal()
    {
        return Input.GetAxis("Horizontal") * Vector3.right;
    }

    public bool IsJump()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }
   
}
