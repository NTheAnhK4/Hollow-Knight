using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySensor : EntityComponent
{
    [SerializeField] protected float radius = 7f;
    [SerializeField] protected Transform entity;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected List<Transform> sensedObjects;
    protected EntityDetection detection;
    protected EntityClassifier classifier;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        entity = transform.parent.parent;
        boxCollider2D = entity.GetComponent<BoxCollider2D>();
    }

    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        detection = new EntityDetection(entity, radius, boxCollider2D);
        classifier = new EntityClassifier();
    }

    protected void DetectObjects()
    {
        classifier.ResetTarget();
        sensedObjects = detection.DetectObjects();
        classifier.ClassifyDetectedObjects(sensedObjects);
    }
    void OnDrawGizmos()
    {
        // Thiết lập màu sắc cho vòng tròn
        Gizmos.color = Color.red; // Màu đỏ

        // Vẽ vòng tròn xung quanh vị trí của đối tượng
        Gizmos.DrawWireSphere(entity.position, radius);
    }

    public object IsPlayerVisible()
    {
        if (classifier.Player == null) return false;
        else return classifier.Player;
    }
    protected void Update()
    {
        DetectObjects();
    }
}
