using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : ChildBehavior
{
    [SerializeField] protected BoxCollider2D playerCollider;
    [SerializeField] protected Rigidbody2D playerRigid;
    [SerializeField] protected bool onGround = true;
    [SerializeField] protected int jumpCounter;
    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        playerCollider = LoadComponent<BoxCollider2D>(playerCollider);
        playerCollider.offset = new Vector2(-0.1650793f, -0.8047616f);
        playerCollider.size = new Vector2(0.6698415f,0.1539688f);
        playerRigid = LoadComponent<Rigidbody2D>(playerRigid);
    }

    protected override void Start()
    {
        base.Start();
        onGround = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            Debug.Log("he");
            onGround = true;
            jumpCounter = 0;
        }
            
    }

    public void Jump(Rigidbody2D entity, float jumpForce)
    {
      
        if (jumpCounter >= 2) return;
        jumpCounter++;
        Debug.Log("Jumping");
        entity.AddForce(Vector3.up * jumpForce);
    }
}
