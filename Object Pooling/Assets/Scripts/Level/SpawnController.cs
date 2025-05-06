using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] public GameObject dropPrefab;
    public static SpawnController Instance { get; set; }


    [SerializeField] List<GameObject> spawnMarkers;
    [SerializeField] List<GameObject> dropsPool;
    [SerializeField] GameObject exit;

    public ISpawnEntities spawnEntities;

    //this is where Strategy Pattern is implemented
    void Start()
    {
        ParseSpawnStrategy();

        if (dropsPool.Count == 0) // start factory pattern
        {
            dropsPool = InstantiateDrops(spawnMarkers);
        }

        spawnEntities.SpawnEntities(spawnMarkers, dropsPool, exit);
    }


    public void ParseSpawnStrategy()
    {
        spawnEntities = PlayerPrefs.GetString("entitySpawnStrategy") switch
        {
            "SpawnRandomStrategy" => SpawnRandomStrategy.Instance,
            "SpawnAllStrategy" => SpawnAllStrategy.Instance,
            _ => SpawnRandomStrategy.Instance,
        };
    }

    // this is the implementation of the Factory pattern.
    //Instantiates dropsPool in amount equal to one less than the number of possible locations.
    // they are stored in List<GameObject> dropsPool
    public List<GameObject> InstantiateDrops(List<GameObject> spawnLocations)
    {
        List<GameObject> aListOfDrops = new();

        for (int i = 0; i < spawnLocations.Count -1; i++) //need to generate one less to accomodate for exit
        {
            //instantiate from dropPrefab, which is mainly just a triangle primitive.
            GameObject aDrop = Instantiate(dropPrefab, Vector3.zero, Quaternion.identity);
            aListOfDrops.Add(aDrop);
            dropPrefab.SetActive(false);
        }

        return aListOfDrops;
    }
}
