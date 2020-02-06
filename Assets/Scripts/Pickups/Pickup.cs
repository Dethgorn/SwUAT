using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnPickup(CharacterPawn picker)
    {
        Debug.Log(gameObject.name + " picked up!");
    }

    protected abstract void DoStuff();

    private void OnTriggerEnter(Collider other)
    {
        CharacterPawn otherpawn = other.GetComponent<CharacterPawn>();
        if (otherpawn != null)
        {
            OnPickup(otherpawn);
            Destroy(gameObject);
        }
        
        
    }
}
