using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataRelay : ParentBehavior
{
    [SerializeField] protected EntityAnim anim;
    [SerializeField] protected EntityMove move;
    [SerializeField] protected EntitySensor sensor;

    public EntityAnim Anim => anim;

    public EntityMove Move => move;

    public EntitySensor Sensor => sensor;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        anim = LoadComponent<EntityAnim>(anim, "Model");
        move = LoadComponent<EntityMove>(move, "Move");
        sensor = LoadComponent<EntitySensor>(sensor, "Sensor");
    }
    
}
