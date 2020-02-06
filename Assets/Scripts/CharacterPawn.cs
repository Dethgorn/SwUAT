using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPawn : MonoBehaviour
{
    // public vars
    public Animator anim;
    public float speed;
    public float dashDistance;
    public float startDashTime;
    public float currentHP;

    // private vars
    private Transform tf;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    public void Move(Vector2 direction)
    {
        anim.SetFloat("Horizontal", direction.x * speed);
        anim.SetFloat("Vertical", direction.y * speed);
    }

    public void Dash()
    {
        // teleport the distance, Dash!
        tf.position += (rb.velocity * dashDistance);
    }

    public void AddHealth(float healthToAdd)
    {
        currentHP += healthToAdd;
    }
}
