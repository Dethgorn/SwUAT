using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{

    public HealthTest playerHealthComponent;

    // Start is called before the first frame update
    void Start()
    {
        // register UpdateHealthUI function with the Event in our health
        playerHealthComponent.OnHealthChange.AddListener(UpdateHealthUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI()
    {
        Debug.Log("HP has changed");
    }

}
