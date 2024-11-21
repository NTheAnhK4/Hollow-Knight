
using Core.Entity;
using UnityEngine;

public class PlayerJump : IMoveStrategy
{
    private bool IsJump()
    {
        return InputManager.Instance.IsJump();
    }
    public void Move(Transform entity, Transform target = null, float speed = 0, Rigidbody2D rb = default)
    {
        if (!IsJump()) return;
        if (rb == null)
        {
            Debug.LogWarning("Rigibody of player is null");
            return;
        }

        rb.AddForce(Vector2.up * speed,ForceMode2D.Impulse);
    }
}
