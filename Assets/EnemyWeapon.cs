using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public CharacterPawn AIpawn;
    [SerializeField] private Weapon[] defaultWeapons;
    private Weapon AIWeapon;

    // vars for shooting at player
    private GameObject player;
    private Transform target;
    [SerializeField] private float maxRange;
    [SerializeField] private float distanceToShoot;
    private Transform AITransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        // get component
        AITransform = GetComponent<Transform>();
        AIpawn = GetComponent<CharacterPawn>();
        // grab a random weapon then call the equip weapon
        AIWeapon = defaultWeapons[Random.Range(0, defaultWeapons.Length)];
        AIpawn.EquipWeapon(AIWeapon);
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToShoot = Vector3.Distance(target.position, AITransform.position);
        if (distanceToShoot < maxRange)
        {
            AIpawn.OnTriggerPull.Invoke();
        }
    }
}
