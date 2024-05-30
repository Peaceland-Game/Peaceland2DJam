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
    [SerializeField] private float timerMax = 2;
    [SerializeField] private float rotationAngle = 75;

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
        transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime);
    }
}
