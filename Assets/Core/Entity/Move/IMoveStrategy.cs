using UnityEngine;

namespace Core.Entity
{
    public interface IMoveStrategy
    {
        void Move(Transform entity, Transform target = null,float speed = 0f, Rigidbody2D rb = default);
       
    }

}

