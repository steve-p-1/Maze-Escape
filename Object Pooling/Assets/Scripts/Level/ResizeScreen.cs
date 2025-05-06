using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeScreen : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private bool isZoomedIn = false;


    //this is the code for the adapter pattern.
    //This class does not directly see how the camera is modified.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isZoomedIn = !isZoomedIn;

            ZoomCamera zoomCamera = new ZoomCamera(isZoomedIn, mainCamera);

            zoomCamera.ModifyZoom();
        }
    }
}
