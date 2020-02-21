using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoGun : Gun
{
    [SerializeField]
    private float fireRate;

    private void Start()
    {
        OnTriggerPull.AddListener(OnPullTrigger);
        OnTriggerRelease.AddListener(OnReleaseTrigger);
    }

    protected override void OnPullTrigger()
    {
        base.OnPullTrigger();
    }

    protected override void OnReleaseTrigger()
    {
        base.OnReleaseTrigger();
    }

    protected override void Fire()
    {
        base.Fire();
    }
    
    protected override void Update()
    {
        base.Update();
    }
}
