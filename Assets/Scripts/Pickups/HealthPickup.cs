using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{

    protected override void OnPickup(CharacterPawn picker)
    {
        picker.AddHealth(10);
        base.OnPickup(picker);
    }
    protected override void DoStuff()
    {

        // included by default
        throw new System.NotImplementedException();
    }
}
