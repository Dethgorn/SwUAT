using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverTest : MonoBehaviour
{

    public HealthTest playerHPComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerHPComponent.currentHealth -= 1;
        }
    }
}
