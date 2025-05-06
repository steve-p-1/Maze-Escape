using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DropOscillate : MonoBehaviour
{
    private int distance = 5;
    private int speed = 1;
    private Vector3 spawnPosition;
    float moveDistance;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //creates smooth wave
        moveDistance = Mathf.Sin(Time.time * speed) * distance;
        transform.position = spawnPosition + new Vector3(1,0,0) * moveDistance;

    }
}
