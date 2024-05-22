using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LookForPlayer : MonoBehaviour
{
    // Establishing the area that the detector sees
    public Camera viewCamera;
    Plane[] planes;

    public Light viewLight;

    // Establishing the dimensions of the player
    public GameObject player;
    Collider playerCollider;

    // Variables for determining when the detector can see the player
    bool lookingUp;
    double lookTimer = 0;
    public double lookThreshold;

    bool playerSeen; // test

    // Start is called before the first frame update
    void Start()
    {
        // Calculating the bounds of the camera view
        planes = GeometryUtility.CalculateFrustumPlanes(viewCamera);

        // Getting the dimensions of the player collider
        playerCollider = player.GetComponent<Collider>();

        // Starting state for whether the detector can see
        lookingUp = false;
        GetComponent<Renderer>().material.color = Color.green;
        viewLight.enabled = false;
        lookTimer = 0;

        playerSeen = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the look timer
        lookTimer += Time.deltaTime;

        // If the look timer exceeds the look threshold,
        // change whether the detector is looking, and reset the look timer
        if(lookTimer >= lookThreshold)
        {
            lookTimer = 0;
            lookingUp = !lookingUp;

            if(lookingUp)
            {
                Debug.Log(name + " is looking up");
                GetComponent<Renderer>().material.color = Color.red;
                viewLight.enabled = true;
            }
            else
            {
                Debug.Log(name + " is looking down");
                GetComponent<Renderer>().material.color = Color.green;
                viewLight.enabled = false;
            }
        }

        // Check if the player is seen by the detector
        if (GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds) && lookingUp)
        {
            playerSeen = true;
            Debug.Log("Player seen by " + name);
        }
        else
        {
            playerSeen = false;
        }
    }
}
