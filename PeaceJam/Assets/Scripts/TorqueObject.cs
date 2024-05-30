using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * William Duprey
 * 5/30/24
 * Torque Object Script
 * Peaceland
 */

public class TorqueObject : MonoBehaviour
{
    [SerializeField] private Vector3 angVelocity;
    [SerializeField] private Vector3 angAcceleration = new Vector3(0, 0, 0);
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float mass = 1;
    [SerializeField] private float radius = 1;
    private float inertia;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate moment of inertia
        inertia = 0.5f * mass * radius * radius;
    }

    // Update is called once per frame
    void Update()
    {
        // Update angular velocity based on acceleration
        angVelocity += angAcceleration * Time.deltaTime;
        angVelocity = Vector3.ClampMagnitude(angVelocity, maxSpeed);

        // Apply angular velocity to direction
        transform.forward += angVelocity * Time.deltaTime;

        // Reset acceleration for next frame
        angAcceleration = Vector3.zero;

        // Face the actual transform at the calculated direction
        transform.rotation = Quaternion.LookRotation(transform.forward);
    }

    internal void ApplyTorque(Vector3 torque)
    {
        angAcceleration += torque / inertia;
    }
}
