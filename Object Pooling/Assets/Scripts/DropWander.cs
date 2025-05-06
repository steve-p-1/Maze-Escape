using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class DropWander : DropDecorator
{
    IDropCommand drop;

    public DropWander(IDropCommand drop) : base(drop) { }

    public override void Execute()
    {
        //Object[] dropTags = GameObject.FindObjectsOfType<DropTag>();
        GameObject[] GOs = GameObject.FindObjectsOfType<GameObject>();
        int i = 0;
        foreach (GameObject GO in GOs)
        {
            if (GO.gameObject.layer == 9) //this is drops layer
            {
                // this is an annoying workaround for the tag system not working.
                GO.AddComponent<DropOscillate>();
            }
        }
    }
}


