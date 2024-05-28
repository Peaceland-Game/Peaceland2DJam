using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnArea : MonoBehaviour
{
    [SerializeField] int angle;
    [SerializeField] bool altTurn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print(other.transform.eulerAngles.y);
            if (((int)other.transform.eulerAngles.y == (360 - angle)) || ((int)other.transform.eulerAngles.y == angle)) // TODO: change to be not bad :3
                return;

            other.GetComponent<CamRotator>().SetTurn(angle, altTurn);
        }
    }
}
