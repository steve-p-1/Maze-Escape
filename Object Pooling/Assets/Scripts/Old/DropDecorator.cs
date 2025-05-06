using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDecorator : IDropCommand
{
    private IDropCommand _DropCommand;

    public DropDecorator(IDropCommand dropCommand)
    {
        _DropCommand = dropCommand;
    }

    public virtual void Execute()
    {
        Debug.Log("base drop handler");
    }

}
