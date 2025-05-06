using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitProxy : MonoBehaviour
{
    private GameObject realExit;
    
    //this is the Proxy pattern
    public void Execute()
    {
        Debug.Log("trying to load resource Exit");

        realExit = Instantiate(Resources.Load<GameObject>("Exit"), transform.position, Quaternion.identity);
        
       this.gameObject.SetActive(false);
    }
}
