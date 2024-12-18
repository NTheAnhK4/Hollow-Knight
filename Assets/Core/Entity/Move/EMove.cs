using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entity
{
    public class EMove : ChildBehavior
    {
        [SerializeField] protected Transform entity;
        [SerializeField] protected float speed = 2f;
        protected IMoveStrategy moveStrategy;
        public virtual void SetMoveStrategy(IMoveStrategy newStrategy)
        {
            moveStrategy = newStrategy;
        }

        public virtual void ExecuteMove(Transform target = null)
        {
            moveStrategy?.Move(entity,target,speed);
        }
    }

}
