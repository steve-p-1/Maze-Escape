using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private ISizeState currentState;
    private GrowState growState= new ();
    private ShrinkState shrinkState = new();
    private KeepState maintainState = new();

    private void Start()
    {
        //default state
        ChangeState(maintainState);
    }


    // Update is called once per frame
    void Update()
    {
        currentState?.Execute(Player);

        if (Input.GetKey(KeyCode.Equals))
        {
            ChangeState(growState);
        }
        else if (Input.GetKey(KeyCode.Minus))
        {
            ChangeState(shrinkState);
        }
        else
        {
            ChangeState(maintainState);
        }
    }

    public void ChangeState(ISizeState sizeState)
    {
        this.currentState = sizeState;
    }
}
