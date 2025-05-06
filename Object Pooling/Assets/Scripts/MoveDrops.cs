using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrops : MonoBehaviour
{
    // this is where the Command pattern is implemented


    private DropWander dropWander;
    private DropStationary dropStationary = new();
    public IDropCommand dropCommand;

    private void SetCommand(IDropCommand aDropCommand)
    {
        dropCommand = aDropCommand;
    }


    void Start() //need to be earlier in start order to prevent errors
    {
        IDropCommand DropStationary = new DropStationary();
        IDropCommand DropWander = new DropWander(DropStationary);

        if (PlayerPrefs.GetString("DropBehaviour", "False") == "False")
        {
            SetCommand(DropStationary);
        }
        else
        {
            Debug.Log("attemping drop wander cmd");
            SetCommand(DropWander);
        }
        dropCommand.Execute();
    }
}
