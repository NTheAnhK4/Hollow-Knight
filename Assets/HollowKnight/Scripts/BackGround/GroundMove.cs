
using System.Collections.Generic;
using UnityEngine;


public class GroundMove : ParentBehavior
{
    [SerializeField] private List<Transform> foreGroundList;
    [SerializeField] private List<Transform> backGroundList;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float centralSpeed = 5f;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadObjects("ForeGround",foreGroundList);
        this.LoadObjects("BackGround",backGroundList);
    }
    private void LoadObjects(string parentName, List<Transform> objectList)
    {
        if (objectList.Count != 0) return;
        Transform parent = transform.Find(parentName);
        foreach (Transform child in parent)
        {
            objectList.Add(child);
        }
    }

    
    private void GetDirection()
    {
        direction = InputManager.Instance.GetHorizontal();
    }
    private void MoveObjects(List<Transform> objectList, bool isForeground)
    {
        int count = objectList.Count;
        for (int i = 0; i < count; ++i)
        {
            float speed = centralSpeed * (i + 1) / (count + 1);
            if (isForeground) speed *= -1;
            objectList[i].Translate(direction * (speed * Time.deltaTime));
        }
    }

    private void Update()
    {
        GetDirection();
        MoveObjects(foreGroundList,true);
        MoveObjects(backGroundList,false);
    }
}
