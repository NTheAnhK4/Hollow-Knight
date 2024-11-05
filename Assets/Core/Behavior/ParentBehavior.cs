
using System;
using UnityEngine;

public class ParentBehavior : MonoBehaviour
{
    protected virtual void LoadComponent(){
        LoadExternalComponent();
        LoadComponentInChild();
        LoadComponentInIt();
    }
    
    protected virtual void LoadExternalComponent()
    {
        
    }

    protected virtual void LoadComponentInChild()
    {
        
    }

    protected virtual void LoadComponentInIt()
    {
        
    }

    protected virtual void ResetValue()
    {
        
    }

    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }

    protected virtual void OnEnable()
    {
        LoadComponent();
        ResetValue();
    }
    protected GameObject AddChildTransform(string transformName)
    {
        GameObject childObject = new GameObject(transformName);
        childObject.transform.parent = this.transform;
        childObject.transform.localPosition = Vector3.zero;
        childObject.transform.localRotation = Quaternion.identity;
        return childObject;
    }
    protected virtual T LoadComponent<T>(T comp, string childName = null, bool searchInParent = false) where T : Component
    {
        if (comp == null)
        {
            comp = searchInParent && transform.parent != null 
                ? transform.parent.GetComponent<T>() ?? transform.parent.gameObject.AddComponent<T>() 
                : childName != null 
                    ? transform.GetComponentInChildren<T>() ?? AddChildTransform(childName).AddComponent<T>() 
                    : transform.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }
        return comp;
    }

}
