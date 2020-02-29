using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]protected float DamageDone;
    protected float AttackSpeed;


    public Transform leftHand;
    public Transform rightHand;

    public virtual void OnPullTrigger()
    {
    }

    public virtual void OnReleaseTrigger()
    {
    }


    // Update is called once per frame
    protected virtual void Update()
    {
    }
}
