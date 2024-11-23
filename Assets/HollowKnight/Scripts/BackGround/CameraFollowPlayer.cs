
using UnityEngine;

public class CameraFollowPlayer : ParentBehavior
{
    public Transform player; // Transform của nhân vật chính
    public float smoothSpeed = 0.125f; // Độ mượt mà
    public Vector2 verticalOffset = new Vector2(0, 2); // Offset trục Oy
    public Vector2 boundsY = new Vector2(-10, 10); // Giới hạn trục Oy

    private void LateUpdate()
    {
        if (player == null) return;

        // Lấy vị trí đích (target position)
        var position = transform.position;
        Vector3 targetPosition = position;
        targetPosition.y = Mathf.Clamp(player.position.y + verticalOffset.y, boundsY.x, boundsY.y);

        // Nội suy để tạo độ mượt
        position = Vector3.Lerp(position, targetPosition, smoothSpeed);
        transform.position = position;
    }
}
