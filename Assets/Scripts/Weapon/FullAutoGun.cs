using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutoGun : Gun
{
    [SerializeField]
    private bool isFiring = false;
    [SerializeField]
    private float fireRate = 0.25f;
    [SerializeField]
    private float muzzleVelocity = 1f;
    [SerializeField]
    private GameObject bullet;

    private float countdown;

    private void Start()
    {
        
        countdown = 0;
    }

    public override void OnReleaseTrigger()
    {
        isFiring = false;
        
    }

    public override void OnPullTrigger()
    {
        isFiring = true;
        
    }

    protected override void Fire()
    {
        // shoot bullets
        GameObject shot = Instantiate(bullet, barrel.position, barrel.rotation) as GameObject;
        // set the bullet data
        Bullet bulletData = shot.GetComponent<Bullet>();
        if (bulletData != null)
        {
            bulletData.damage = DamageDone;
            bulletData.moveSpeed = muzzleVelocity;
            //change layer
            shot.gameObject.layer = gameObject.layer;
        }
    }

    protected override void Update()
    {
        // count down each frame
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        if (isFiring && ammoCount > 0 && countdown <= 0)
        {
            ammoCount--;
            Fire();
            countdown = fireRate;
        }
    }
}
