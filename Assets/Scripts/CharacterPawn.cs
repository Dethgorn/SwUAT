using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPawn : MonoBehaviour
{
    // public vars
    public Animator anim;
    

    // private vars
    [SerializeField] private float speed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float startDashTime;
    [SerializeField] private Transform attachmentPoint;
    private Transform tf;
    private Rigidbody rb;
    private PlayerHealth playerHP;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerHP = GetComponent<PlayerHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (i < 1)
        {
            EquipWeapon(GameManager.instance.equippedWeapon);
            i++;
        }
            
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

    public void AddHealth(int healthToAdd)
    {
         playerHP.SetHealth(healthToAdd);
    }

    public void EquipWeapon(Weapon gun)
    {
        // try out different instantiates
        GameManager.instance.equippedWeapon = Instantiate(gun) as Weapon;
        GameManager.instance.equippedWeapon.transform.SetParent(attachmentPoint);
        GameManager.instance.equippedWeapon.transform.localPosition = gun.transform.localPosition;
        GameManager.instance.equippedWeapon.transform.localRotation = gun.transform.localRotation;
    }
}
