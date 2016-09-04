﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Collider2D groundDetector;
    public float jumpForce = 1.0f;
    public float walkSpeed = 10.0f;

    private int groundLayer;
    private Rigidbody2D rb;

    void Awake()
    {
        this.groundLayer = LayerMask.GetMask("Ground");
        this.rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0 && CanJump())
        {
            Jump();
        }
    }

    void Update()
    {
        Walk(Input.GetAxis("Horizontal"));
    }

    bool CanJump()
    {
        return groundDetector.IsTouchingLayers(groundLayer);
    }

    void Jump()
    {
        this.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Walk(float direction)
    {
        this.transform.position += Vector3.right * (direction * walkSpeed * Time.deltaTime);
    }
}
