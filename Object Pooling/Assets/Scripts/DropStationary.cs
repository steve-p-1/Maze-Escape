using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropStationary : IDropCommand
{
    // this is the concrete implementation


    public void Execute()
    {

        Debug.Log("default Drop decorator");
    }
}
