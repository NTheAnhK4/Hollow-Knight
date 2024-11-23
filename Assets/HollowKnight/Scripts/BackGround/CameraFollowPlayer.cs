
using UnityEngine;

public class CameraFollowPlayer : ParentBehavior
{
   
    public Transform player; // Transform của nhân vật chính
    [SerializeField]  Vector3 offSet = new Vector3(0, 3, 0);
    protected override void LoadExternalComponent()
    {
        base.LoadExternalComponent();
        if(player == null) player = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        if (player == null) return;
        transform.position = player.position + offSet;
    }
}
