using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPrefabs : MonoBehaviour
{
    public static DropPrefabs Instance { get; set; }
     [SerializeField] public GameObject StationaryDropPrefab;
    [SerializeField] public GameObject WanderingDropPrefab;
}
