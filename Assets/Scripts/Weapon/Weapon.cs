using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    protected float DamageDone;
    protected float AttackSpeed;


    public Transform leftHand;
    public Transform rightHand;

    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;

    protected virtual void OnPullTrigger()
    {
    }

    protected virtual void OnReleaseTrigger()
    {
    }


    // Update is called once per frame
    protected virtual void Update()
    {
    }
}
