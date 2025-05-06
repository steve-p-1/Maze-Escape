using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullExit : IExitContract
{
    //this will prevent the Exit from functioning properly
    public void SpawnExit(GameObject exit)
    {
        Debug.LogWarning(GetType().Name + "Null Exit service being used!");
    }
}
