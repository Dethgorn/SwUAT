using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public CharacterPawn AIpawn;
    [SerializeField] private Weapon[] defaultWeapons;
    private Weapon AIWeapon;

    // Start is called before the first frame update
    void Start()
    {
        // get component
        AIpawn = GetComponent<CharacterPawn>();
        // grab a random weapon then call the equip weapon
        AIWeapon = defaultWeapons[Random.Range(0, defaultWeapons.Length)];
        AIpawn.EquipWeapon(AIWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
