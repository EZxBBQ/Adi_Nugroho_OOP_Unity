using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * stopClamp / (timeToStop * timeToStop);
    }

    public void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        
        moveDirection = new Vector2(xInput, yInput).normalized;
        if (moveDirection.magnitude != 0)
        {
            rb.velocity += (moveVelocity + (GetFriction() * (3/5))) * moveDirection * Time.deltaTime;
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x), 
                            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y));
        }
        else 
        {
            rb.velocity += GetFriction() * (2 * rb.velocity) * Time.deltaTime;
        }
    }

    Vector2 GetFriction()
    {
        if (moveDirection.magnitude != 0)
        {
            return moveFriction;
        }
        else
        {
            return stopFriction;
        }
    }

    void MoveBound()
    {

    }

    public bool IsMoving()
    {
        if (moveDirection.magnitude != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
