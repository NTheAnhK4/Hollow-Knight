using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entity
{
    public class EGroundEscape : IMoveStrategy
    {
        

        public void Move(Transform entity, Transform target = null, float speed = 0)
        {
            Debug.Log("Escaping on ground");
        }
    }

}
