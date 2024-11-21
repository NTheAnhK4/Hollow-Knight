using System;
using System.Collections;
using System.Collections.Generic;
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

        protected void OnEnable()
        {
            prePosX = enity.position.x;
            curStateAnim = new EStateAnim(anim, String.Empty);
        }

        protected void RotateAnim()
        {
            curPosX = enity.position.x;
            if(curPosX - prePosX < -0.001) transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            if(curPosX - prePosX > 0.001) transform.rotation = quaternion.Euler(new Vector3(0,0,0));
            prePosX = curPosX;

        }

        public void ChangeState(EStateAnim newStateAnim)
        {
            curStateAnim?.Enter();
            curStateAnim = newStateAnim;
            curStateAnim?.Exit();
        }

        protected void Update()
        {
            RotateAnim();
        }
    }

}
