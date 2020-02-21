using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    private bool isRagdoll;

    private Animator anim;
    private Rigidbody mainRigidbody;
    private Collider mainCollider;

    private Rigidbody[] ragdollRigidbodies;
    private Collider[] ragdollColliders;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeVariables()
    {
        anim = GetComponent<Animator>();
        mainRigidbody = GetComponent<Rigidbody>();
        mainCollider = GetComponent<Collider>();

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
    }
    
    public void EnableRagdoll()
    {
        isRagdoll = true;

        // turn on ragdoll rigid
        for (int i =0; i < ragdollRigidbodies.Length; i++)
        {
            ragdollRigidbodies[i].isKinematic = false;
        }
        // turn on ragdoll collider
        foreach(Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
        //turn off anim
        anim.enabled = false;
        // turn off main rigid
        mainRigidbody.isKinematic = false;
        // turn off main collider
        mainCollider.enabled = false;


    }

    public void DisableRagdoll()
    {
        isRagdoll = false;

        // turn off ragdoll rigid
        foreach(Rigidbody rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        // turn off ragdoll collider
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
        //turn on anim
        anim.enabled = true;
        // turn on main rigid
        mainRigidbody.isKinematic = true;
        // turn on main collider
        mainCollider.enabled = true;
    }

    public void ToggleRagdoll()
    {
        if(isRagdoll)
        {
            DisableRagdoll();
        }

    }
}
