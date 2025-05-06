using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public void OnEnable() //called before Awake
    {
        Debug.Log("Client loaded");
        //this puts the NullExit in
        BasicLocator.Initialize();

        //now register actual services
        BasicLocator.RegisterExit(new CreateExit());
    }
}
