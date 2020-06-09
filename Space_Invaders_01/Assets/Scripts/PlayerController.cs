using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{
    Vector2 playerInput;
    public float maxSpeed = 5;
    public float maxAcceleration = 10;
    Vector3 velocity;
    float BoundsSide = 10;
    float bounciness = .2f;

    public Transform turret;

    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile(turret,10);
        }
    }
    void PlayerMovement()
    {
        playerInput.x = Input.GetAxis("Horizontal");

        Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, 0f) * maxSpeed;
        
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        Vector3 displacement = velocity * Time.deltaTime;
        
        Vector3 newPosition = transform.localPosition + displacement;
        if(Mathf.Abs( newPosition.x ) > BoundsSide)
        {
            velocity.x = -velocity.x * bounciness;
        }
        else
        {
            transform.localPosition = newPosition;
        }
    }

    
    
    
}
