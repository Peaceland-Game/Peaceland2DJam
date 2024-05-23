using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    //the number for the table layer
    private int tableLayer = 1 << 3;
    //the number for the key layer
    private int keyLayer = 1 << 6;

    void Update()
    {
        //detmines wether or not it is colliding with the table or key
        if (Physics.CheckBox(transform.position, transform.localScale, new Quaternion(), tableLayer, new QueryTriggerInteraction()))
        {
            Debug.Log("Collision with table");
        }

        if (Physics.CheckBox(transform.position, transform.localScale, new Quaternion(), keyLayer, new QueryTriggerInteraction()))
        {
            Debug.Log("Collision with key");
        }
    }
}
