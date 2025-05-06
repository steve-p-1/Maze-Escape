using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    //this toggles bar functionality
    private void OnEnable()
    {
        gameObject.transform.parent.gameObject.layer = 7; //walls
    }


    private void OnDisable()
    {
        this.gameObject.transform.parent.gameObject.layer = 8; //exit
    }
}
