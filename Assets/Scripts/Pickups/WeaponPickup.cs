using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    protected override void OnPickup(CharacterPawn picker)
    {
        if (picker != null)
        {
            picker.EquipWeapon(weapon);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterPawn otherpawn = other.GetComponent<CharacterPawn>();
        if (otherpawn != null)
        {
            OnPickup(otherpawn);
            Destroy(gameObject);
        }
    }
}
