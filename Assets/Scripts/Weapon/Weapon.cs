using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public float DamageDone;
    public float AttackSpeed;

    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;

    protected virtual void OnPullTrigger()
    {

    }

    protected virtual void OnReleaseTrigger()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
