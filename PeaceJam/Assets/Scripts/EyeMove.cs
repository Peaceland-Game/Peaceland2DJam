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
    [SerializeField] private Rigidbody eyesRigidBody;
    [SerializeField] private Vector3 torque;

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
        if(Mathf.Abs(dotProduct) < 0.95
            && eyesRigidBody.GetAccumulatedTorque() == Vector3.zero)
        {
            // TODO: Torque is somehow related to rotation angle set in the TestRotate
            // script, so figure out why that is happening.
            eyesRigidBody.AddRelativeTorque((dotProduct * force) * transform.up,
                ForceMode.VelocityChange);
        }
        torque = eyesRigidBody.GetAccumulatedTorque();
    }
}
