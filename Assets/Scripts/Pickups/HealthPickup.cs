using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
        Destroy(this.gameObject, 10f);
    }
    protected override void OnPickup(CharacterPawn picker)
    {
        picker.AddHealth(10);
        //base.OnPickup(picker);
    }
    
    private void Update()
    {
        tf.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
