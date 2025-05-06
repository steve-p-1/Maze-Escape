using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLocator : MonoBehaviour
{
    //mostly adapted from script in class
    //this is the Service Locator pattern
    //register service with middleman, this class.

    private static IExitContract exiting;

    private static IExitContract nullExit= new NullExit();

    public static void Initialize()
    {
        //sets null as default
        exiting = nullExit;
    }


    public static void RegisterExit(IExitContract service)
    {
        exiting = service;
        Debug.Log("Exit service Registered");
    }


    public static IExitContract GetExitService()
    {
        return exiting;
    }

}
