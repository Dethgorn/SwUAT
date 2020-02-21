using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutoGun : Gun
{
    [SerializeField]
    private bool isFiring = false;
    [SerializeField]
    private float fireRate = 0.25f;

    private void Start()
    {
        OnTriggerPull.AddListener(OnPullTrigger);
        OnTriggerRelease.AddListener(OnReleaseTrigger);
    }

    protected override void OnReleaseTrigger()
    {
        isFiring = true;
        base.OnReleaseTrigger();
    }

    protected override void OnPullTrigger()
    {
        isFiring = false;
        base.OnPullTrigger();
    }

    protected override void Fire()
    {
        // shoot bullets
        base.Fire();
    }

    protected override void Update()
    {
        if (isFiring)
        {
            // user fireRate to only call it
            Fire();
        }
    }
}
