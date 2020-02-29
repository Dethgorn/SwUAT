using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoGun : Gun
{
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float muzzleVelocity = 1f;
    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        
    }

    public override void OnPullTrigger()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            Fire();
        }
    }

    public override void OnReleaseTrigger()
    {
        base.OnReleaseTrigger();
    }

    protected override void Fire()
    {
        // shoot bullets
        GameObject shot = Instantiate(bullet, barrel.position, barrel.rotation) as GameObject;
        // set the bullet data
        Bullet bulletData = shot.GetComponent<Bullet>();
        
        if (bulletData != null)
        {
            Debug.Log(shot);
            bulletData.damage = DamageDone;
            bulletData.moveSpeed = muzzleVelocity;
            //change layer
            shot.gameObject.layer = gameObject.layer;
        }
        
    }
    
    protected override void Update()
    {
        // shoot bullets
        GameObject shot = Instantiate(bullet, barrel.position, barrel.rotation) as GameObject;
        
    }
}
