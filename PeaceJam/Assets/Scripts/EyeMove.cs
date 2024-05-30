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
    [SerializeField] private float rotateSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyesAngle = transform.forward;
        Vector3 bodyAngle = bodyTransform.forward;
        float dotProduct = Vector3.Dot(eyesAngle, bodyAngle);

        // Code partially copied from Unity Docs:
        // https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html
        float singleStep = rotateSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(
            eyesAngle, 
            (bodyAngle * dotProduct).normalized,
            singleStep, 
            0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
