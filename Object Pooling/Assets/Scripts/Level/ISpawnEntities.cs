using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnEntities
{
    string Name();
    void SpawnEntities(List<GameObject> locations, List<GameObject> entities, GameObject exit);
}
