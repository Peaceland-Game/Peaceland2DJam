using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 1f;

    [SerializeField]
    float jumpSpeed = 5.0f;

    private Vector3 desiredVel;
    private Vector3 vel;

    public bool desiredJump;

    Rigidbody rb;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        desiredVel = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        desiredVel = Vector3.ClampMagnitude(desiredVel, 1.0f) * maxSpeed;

        desiredJump |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        vel = rb.velocity;
        // Normal Movement
        float maxChangeSpeed = maxAcceleration * Time.deltaTime;

        vel.x =
            Mathf.MoveTowards(vel.x, desiredVel.x, maxChangeSpeed);
        vel.z =
            Mathf.MoveTowards(vel.z, desiredVel.z, maxChangeSpeed);
        
        // Jumping 
        if (desiredJump)
        {
            desiredJump = false;
            Jump();
        }

        // Send to rigidbody 
        rb.velocity = vel;
    }

    void Jump()
    {
        // Change instant velocity not desired 
        vel.y += jumpSpeed;
    }


    private void Displace(Vector2 displacement)
    {
        Vector3 target = this.transform.position + new Vector3(displacement.x, 0.0f, displacement.y); ;
        this.transform.position = target;
    }
}
