using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExit : IExitContract
{

    public void SpawnExit(GameObject exit)
    {
        exit.gameObject.GetComponent<ExitProxy>()?.Execute();
    }
}
