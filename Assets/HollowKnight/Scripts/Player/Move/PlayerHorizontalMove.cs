
using Core.Entity;
using UnityEngine;

public class PlayerHorizontalMove : IMoveStrategy
{
    private Vector3 direction;
    private void GetDirection()
    {
        direction = InputManager.Instance.GetHorizontal();
    }
    public void Move(Transform entity, Transform target = null, float speed = 0, Rigidbody2D rb = default)
    {
        GetDirection();
        entity.Translate(direction * speed *  Time.deltaTime);
    }
}
