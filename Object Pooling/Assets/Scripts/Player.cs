using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.layer == 8) //this is Exit
        {
            Level.Instance.EndGame("Win",  Level.timer);
        }
        else if (collision.gameObject.layer == 9) //this is a drop
        {
            collision.gameObject.SetActive(false);

            SpawnRandomStrategy.Instance?.SpawnNextDrop(); //can be null if not using SpawnRandomStrategy
            Level.Instance.CollectDrops();
        }

    }
}
