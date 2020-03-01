using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    // exposed vars for ease

    // private
    private GameObject badguy;
    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnManager()
    {
        if (GameManager.instance.currentActiveEnemies.Count >= GameManager.instance.maxActiveEnemies)
        {
            return;
        }
        else
        {
            Spawn();
        }
    }

    void Spawn()
    {
        // do the random here to help keep it clean
        badguy = GameManager.instance.enemies[Random.Range(0, GameManager.instance.enemies.Length)];
        spawnPoint = GameManager.instance.spawnPoints[Random.Range(0, GameManager.instance.spawnPoints.Length)];
        // spawn the bad guys
        Instantiate(badguy, spawnPoint.position, Quaternion.identity);
    }
}
