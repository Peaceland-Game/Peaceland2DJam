using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.TerrainUtils;

public class PlayerController : MonoBehaviour
{

    [Header("Controls")]
    [SerializeField] float speed;
    [SerializeField] float checkRadius;
    [SerializeField] float checkDis;
    [SerializeField] LayerMask terrainMask;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = (new Vector3(horizontal, 0, vertical)).normalized;
        if (Physics.CheckSphere(this.transform.position + direction * checkDis, checkRadius, terrainMask))
        {
            return;
        }

        this.transform.position += direction * speed * Time.deltaTime;

       /* if (direction == Vector3.zero)
        {
            vertical = -1;
        }
        if (manager.TimeLeft <= (0.25f * startTime))
        {
            SetSprite(vertical, horizontal, front75, back75, right75, left75);
        }
        else if (manager.TimeLeft <= (0.50f * startTime))
        {
            SetSprite(vertical, horizontal, front50, back50, right50, left50);
        }
        else if (manager.TimeLeft <= (0.75f * startTime))
        {
            SetSprite(vertical, horizontal, front25, back25, right25, left25);
        }
        else
        {
            SetSprite(vertical, horizontal, front0, back0, right0, left0);
        }*/
    }

    private void OnDrawGizmosSelected()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = (new Vector3(horizontal, 0, vertical)).normalized;
        Gizmos.DrawWireSphere((this.transform.position + direction * checkDis), checkRadius);
    }
}
