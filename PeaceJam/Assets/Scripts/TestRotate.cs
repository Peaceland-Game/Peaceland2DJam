using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * William Duprey
 * 5/30/24
 * Test Rotation Script
 * Peaceland
 */

public class TestRotate : MonoBehaviour
{
    private float timer = 0;
    private float timerMax = 2;
    private float rotationAngle = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerMax)
        {
            timer = 0;
            rotationAngle = -rotationAngle;
        }
        transform.Rotate(transform.up, rotationAngle * Time.deltaTime);
    }
}
