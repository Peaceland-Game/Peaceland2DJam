using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{  
   //Declare all of the game objects
   public GameObject outerLock;
   public GameObject middleLock;
   public GameObject innerLock;

   
    // Start is called before the first frame update
    void Start()
   {
      
        middleLock.SetActive(false);
        innerLock.SetActive(false);

        

    }
    
    void Update()
    {
        //Setting the Y rotationangle for each part of the lock
        Transform outerTransform = outerLock.transform;
        Transform midTransform = middleLock.transform;
        Transform innerTransform = innerLock.transform;

        Quaternion oRotation = outerTransform.rotation;
        Quaternion mRotation = midTransform.rotation;
        Quaternion iRotation = innerTransform.rotation;

        float y = oRotation.eulerAngles.y;
        float z = mRotation.eulerAngles.y;

        Debug.Log(y);
        Debug.Log(z);

        //if the lock is active, check and see if it is in the range
        if (outerLock.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (oRotation.eulerAngles.y >= 90 && oRotation.eulerAngles.y <= 120)
                {
                    //if it is show the nect part 
                    middleLock.SetActive(true);

                }
                else
                {
                    return;
                }
               

            }
            
        }

        //Repeat steps above with the middle lock
        if (middleLock.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (mRotation.eulerAngles.y >= 315 && mRotation.eulerAngles.y <= 340)
                {
                    innerLock.SetActive(true);
                }

            }

        }

    }
   
  

}
