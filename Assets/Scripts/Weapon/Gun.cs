using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    
    protected float ammoCount;

    protected override void OnPullTrigger()
    {
        base.OnPullTrigger();
    }

    protected override void OnReleaseTrigger()
    {
        base.OnReleaseTrigger();
    }

    protected virtual void Fire()
    {
    }

    protected override void Update()
    {
    }
}
