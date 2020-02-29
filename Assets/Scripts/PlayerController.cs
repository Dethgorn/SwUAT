using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterPawn pawn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoving();
        HandleShooting();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pawn.Dash();
        }
        
    }

    private void HandleMoving()
    {
        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            pawn.OnTriggerPull.Invoke();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            pawn.OnTriggerRelease.Invoke();
        }
    }

}
