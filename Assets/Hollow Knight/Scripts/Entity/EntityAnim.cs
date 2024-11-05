using System;
using UnityEngine;
using UnityEngine.Serialization;


public class EntityAnim : EntityComponent
{
    [SerializeField] public Transform entity;
    [SerializeField] protected Animator anim;
    [SerializeField] protected Vector3 prePosition;
    [SerializeField] protected Vector3 curPosition;
    protected AnimState curAnim;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        if (entity == null) entity = transform.parent.parent;
    }

    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        if (anim == null) anim = transform.GetComponent<Animator>();
        
    }

    protected override void Start()
    {
        base.Start();
        prePosition = entity.position;
        curAnim = new AnimState(anim, string.Empty);
    }

    private void RotateAnim()
    {
        curPosition = entity.position;
        if (Math.Abs(curPosition.x - prePosition.x) < 0.001f)
        {
            prePosition = curPosition;
            return;
        }
        float angle = 180;
        if (curPosition.x < prePosition.x) angle = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0,angle,0));
        prePosition = curPosition;
    }
    
    public void ChangeState(string nextState, object preValue = null, object newValue = null)
    {
        curAnim?.Exit(preValue);
        curAnim = new AnimState(anim, nextState);
        curAnim?.Enter(newValue);
    }
    private void Update()
    {
        RotateAnim();
    }
}
