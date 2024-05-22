using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableMemory : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    private CameraManager manager;
    private bool isFocusedOn;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<CameraManager>();
        if (manager == null)
            Debug.LogError("Camera manager not in scene");

        isFocusedOn = false;
    }

    private void Update()
    {
        if(isFocusedOn)
        {
            if(Input.GetAxisRaw("Cancel") >= 0.1f)
            {
                manager.SwapToMainCam();
            }
        }
    }

    /// <summary>
    /// Called when selected by player to focus on 
    /// and give option to play memory 
    /// </summary>
    public void SelectMemory()
    {
        if (manager == null)
            return;

        isFocusedOn = true;
        manager.SwapCamera(cam);
    }
}
