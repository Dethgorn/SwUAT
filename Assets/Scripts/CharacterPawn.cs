using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPawn : MonoBehaviour
{
    public Animator anim;
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        anim.SetFloat("Horizontal", direction.x * speed);
        anim.SetFloat("Vertical", direction.y * speed );
    }
    
}
