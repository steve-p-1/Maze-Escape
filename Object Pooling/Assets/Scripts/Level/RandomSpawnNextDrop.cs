using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomSpawnNextDrop : ISpawnNextDrop
{
    static System.Random random = new();

    public List<GameObject> positions = new();
    public List<GameObject> entities;
    public GameObject exit;
    private int i;
    private int index;

    // collect parameters
    public RandomSpawnNextDrop(List<GameObject> positions, List<GameObject> entities, GameObject exit)
    {
        this.positions = positions;
        this.entities = entities;
        this.exit = exit;
    }
    // use factory pattern
    public void Execute()
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
    }
}
