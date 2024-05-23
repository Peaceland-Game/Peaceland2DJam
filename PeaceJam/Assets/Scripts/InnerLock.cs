using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLock : MonoBehaviour
{
    float rotationSpeed = 0.4f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);

        if (Input.GetMouseButtonDown(0))
        {
            rotationSpeed *= 0;
        }
    
    }
}
