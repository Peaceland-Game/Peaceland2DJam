using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * William Duprey
 * 5/30/24
 * Springy Eye Movement Script
 * Peaceland
 */

public class EyeMove : MonoBehaviour
{
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private float force = 1;
    [SerializeField] private float dotProduct;
    [SerializeField] private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyesAngle = transform.forward;
        Vector3 bodyAngle = bodyTransform.forward;
        dotProduct = Vector3.Dot(eyesAngle, bodyAngle);

        // Only apply torque if the eye angle is offset enough
        // from the body angle, and only if there isn't already
        // torque being applied to the eyes
        if(dotProduct > -.99 && dotProduct < .99
            && body.GetAccumulatedTorque() == Vector3.zero)
        {
            body.AddTorque((dotProduct * force) * transform.up,
                ForceMode.VelocityChange);
        }        
    }
}
