using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowState : ISizeState
{
    // one implementation of State pattern
    public void Execute(GameObject Player)
    {
        if (Player.transform.localScale.x < 4.2)
        {
            Debug.Log("In Grow State");
            Player.transform.localScale = new Vector3(Player.transform.localScale.x * 1.02f, Player.transform.localScale.y * 1.02f, Player.transform.localScale.z * 1.02f);
        }
    }
}
