using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ZoomCamera : MonoBehaviour, IZoom
{
    Camera mainCamera;
    public  bool isZoomedIn;


   public ZoomCamera(bool _IsZoomedIn, Camera mainCamera)
    {
        isZoomedIn = _IsZoomedIn;
        this.mainCamera = mainCamera;
    }

    //this is specific to orthographic perspective.
    public void ModifyZoom()
    {
        if (isZoomedIn)
        {
        mainCamera.orthographicSize = 35;
        }
        else
        {
            mainCamera.orthographicSize = 5;
        }
    }
}
