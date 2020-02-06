using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthTest: MonoBehaviour
{
    public UnityEvent OnHealthChange = new UnityEvent();

    private int currentHP;
    public int currentHealth
    {
        get { return currentHP; }
        set
        {
            // set private version
            currentHP = value;
            // notify observers
            OnHealthChange.Invoke();
        }
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
