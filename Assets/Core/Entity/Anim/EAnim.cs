using System;

using Unity.Mathematics;
using UnityEngine;

namespace Core.Entity
{
    public class EAnim : ChildBehavior
    {
        [SerializeField] protected Transform enity;
        [SerializeField] protected Animator anim;
        [SerializeField] protected float prePosX;
        [SerializeField] protected float curPosX;
        protected EStateAnim curStateAnim;
        protected EStateAnim preStateAnim;
        protected override void LoadComponentInIt()
        {
            base.LoadComponentInIt();
            if (anim == null) anim = GetComponent<Animator>(); 
        }

        protected override void LoadComponentInParent()
        {
            base.LoadComponentInParent();
            if (enity == null) enity = transform.parent;
        }

        protected virtual void OnEnable()
        {
            prePosX = enity.position.x;
            curStateAnim = new EStateAnim(anim, String.Empty);
            preStateAnim = curStateAnim;
        }

        protected void RotateAnim()
        {
            curPosX = enity.position.x;
            if(curPosX - prePosX < -0.001) transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            if(curPosX - prePosX > 0.001) transform.rotation = quaternion.Euler(new Vector3(0,0,0));
            prePosX = curPosX;

        }

        public void ChangeState(string stateName, object valueEnter = null, object valueExit = null)
        {
            EStateAnim newStateAnim = new EStateAnim(anim, stateName, valueEnter, valueExit);
            if(!curStateAnim.IsTriggerState) preStateAnim = curStateAnim;
            curStateAnim?.Exit();
            curStateAnim = newStateAnim;
            curStateAnim?.Enter();
        }

        public void TurnPreState()
        {
            curStateAnim?.Exit();
            curStateAnim = preStateAnim;
            curStateAnim?.Enter();
        }
        protected void Update()
        {
            RotateAnim();
        }
    }

}
