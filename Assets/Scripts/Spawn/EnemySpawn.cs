using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 1f;
    
    // private
    private GameObject badguy;
    private Transform spawnPoint;
    private PlayerHealth enemyHP;
    private int enemySpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnManager", 1f, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnManager()
    {
        if (GameManager.instance.currentEnemyCount >= GameManager.instance.maxActiveEnemies)
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

        //GameManager.instance.currentActiveEnemies.Add(badguy); // this is a work in progress
        // add to the count
        GameManager.instance.currentEnemyCount++;
        enemySpawnCount++;
        // grab the component and add a listener
        enemyHP = badguy.GetComponent<PlayerHealth>();
        if (enemyHP != null)
        {
            enemyHP.onDie.AddListener(HandleEnemyDeath);
        }

        if (enemySpawnCount > GameManager.instance.maxEnemySpawnCount)
        {
            CancelInvoke("SpawnManger");
        }
    }

    void HandleEnemyDeath()
    {
        // remove from count
        GameManager.instance.currentEnemyCount--;
        // todo: remove listener?
    }
}
