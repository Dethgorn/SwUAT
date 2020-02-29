using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField]
    protected float ammoCount;
    
    [SerializeField]
    protected Transform barrel;

    public override void OnPullTrigger()
    {
        base.OnPullTrigger();
    }

    public override void OnReleaseTrigger()
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
