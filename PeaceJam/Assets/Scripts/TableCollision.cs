using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TableCollision : MonoBehaviour
{
    private int tables = 1 << 3;
    private int key = 1 << 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Physics.CheckBox(transform.position, transform.localScale, new Quaternion(), tables, new QueryTriggerInteraction()))
        {
            Debug.Log("Collision with table");
        }

        if (Physics.CheckBox(transform.position, transform.localScale, new Quaternion(), key, new QueryTriggerInteraction()))
        {
            Debug.Log("Collision with key");
        }
    }
}
