using System.Collections.Generic;
using UnityEngine;

public class SpawnAllStrategy : MonoBehaviour, ISpawnEntities
{
    public static SpawnAllStrategy Instance { get; set; }

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


    // this is where Object Pooling is implemented
    public void SpawnEntities(List<GameObject> locations, List<GameObject> entitiesPool, GameObject exit)
    {
        Level.Instance.SetDropsToCollect(entitiesPool.Count); //gate the exit until all dropsPool are collected

        List<GameObject> positions = new(locations);

        for (int i = 0; i < entitiesPool.Count; i++)
        {
            entitiesPool[i].SetActive(true);
            entitiesPool[i].transform.position = positions[i].transform.position;
        }

        //set exit to the last position
        exit.SetActive(true);
        exit.transform.position = positions[^1].transform.position;

        positions.Remove(positions[^1]);
    }


    public string Name() // do this for easy identitfication
    {
        return "SpawnAllStrategy";
    }
}
