using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSpawnNextDrop : ISpawnNextDrop
{

    public List<GameObject> positions = new();
    public List<GameObject> entities;
    public GameObject exit;


    public AllSpawnNextDrop(List<GameObject> positions, List<GameObject> entities, GameObject exit)
    {
        this.positions = positions;
        this.entities = entities;
        this.exit = exit;
    }


    public void Execute()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].SetActive(true);
            entities[i].transform.position = positions[i].transform.position;
        }

        //set exit to the last position
        exit.SetActive(true);
        exit.transform.position = positions[^1].transform.position;

        positions.Remove(positions[^1]);
    }
}

