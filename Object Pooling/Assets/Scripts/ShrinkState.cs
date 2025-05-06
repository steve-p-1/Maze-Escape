using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkState : ISizeState
{
public void Execute(GameObject Player)
    {
        if (Player.transform.localScale.x > 0.03)
        {
            Debug.Log("In Shrink State");
        Player.transform.localScale = new Vector3(Player.transform.localScale.x * 0.98f, Player.transform.localScale.y * 0.98f, Player.transform.localScale.z * 0.98f);

        }

    }
}
