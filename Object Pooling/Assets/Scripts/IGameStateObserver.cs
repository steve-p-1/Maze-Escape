using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public interface IGameStateObserver 
{

    public void UpdateState(string EndState, float timer);
}
