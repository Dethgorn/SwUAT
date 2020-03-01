using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Weapon equippedWeapon;

    public GameObject[] enemies;
    public Transform[] spawnPoints;

    //public List<GameObject> currentActiveEnemies; // this is a work in progress
    public int currentEnemyCount;
    public int maxActiveEnemies;

    public int maxEnemySpawnCount;

    // Start is called before the first frame update
    void Awake()
    {
        // Setup the singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
