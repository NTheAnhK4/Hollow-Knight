using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityClassifier 
{
    public Transform Player { get; private set; }

    public EntityClassifier()
    {
        
    }

    public void ResetTarget()
    {
        Player = null;
    }

    private void ClassifyEntity(Transform obj)
    {
        if(obj == null) return;
        switch (obj.tag)
        {
            case "Player":
                Player = obj;
                break;
        }
    }
    public void ClassifyDetectedObjects(List<Transform> detectedObjects)
    {
        if (detectedObjects.Count <= 0) return;
        foreach (Transform obj in detectedObjects)
        {
            ClassifyEntity(obj);
        }
    }   
}
