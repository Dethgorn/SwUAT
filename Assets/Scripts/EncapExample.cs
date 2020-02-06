using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncapExample : MonoBehaviour
{

    [SerializeField] private int currency;
    [SerializeField] private int currentHealth;
    private int maxHealth;

    public int gold
    {
        get
        {
            return currency / 10000;
        }
        private set
        {
            currency = 10000 * value;
        }
    }

    public int silver
    {
        get { return currency / 100; }
        set { currency = 100 * value; }
    }

    public float healthPercentage
    {
        get { return (float)currentHealth / (float)maxHealth; }
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
