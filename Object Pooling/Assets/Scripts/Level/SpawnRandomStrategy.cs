using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class SpawnRandomStrategy : MonoBehaviour, ISpawnEntities
{
    static System.Random random = new();


    public List<GameObject> positions = new();
    public List<GameObject> entities;
    public GameObject exit;

    int i = 0;
    int index = 0;

    public ISpawnNextDrop spawnNextDrop;

    public static SpawnRandomStrategy Instance { get; set; }

    private void Awake()
    {

        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

    }

    // this starts the spawn process. rest is handled by  SpawnNextRandomEntity()
    public void SpawnEntities(List<GameObject> _locations, List<GameObject> _entities, GameObject anExit)
    {
        //need to do this to prevent deleting entries from original list
        positions = new(_locations);
        entities = new(_entities);
        exit = anExit;


        Level.Instance.SetDropsToCollect(0); //don't gate the exit
        SpawnNextDrop();
    }


    public void SpawnNextDrop()
    {
        if (positions.Count == 0) return;

        if (positions.Count == 1)
        {
            exit.SetActive(true);
            exit.transform.position = positions[0].transform.position;
            positions.Remove(positions[0]);
            return;
        }

        index = random.Next(0, positions.Count); //pick an entity at random

        entities[i].SetActive(true);
        //entities[i].GetComponent<DropPrefabs>().enabled = true; //this allows the dropsPool to call this method upon its disabling.

        entities[i].transform.position = positions[index].transform.position;
        positions.Remove(positions[index]); //prevent repeat selections
        i++;

        // need a better way to do this
        gameObject.GetComponent<MoveDrops>().dropCommand.Execute();
    }


    public string Name() // do this for easy identitfication
    {
        return "SpawnRandomStrategy";
    }

}
