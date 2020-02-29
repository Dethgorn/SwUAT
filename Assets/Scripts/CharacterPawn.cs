using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    private Weapon weapon;


    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerHP = GetComponent<PlayerHealth>();
        weapon = GameManager.instance.equippedWeapon;
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    public void Move(Vector3 direction)
    {
        direction = transform.InverseTransformDirection(direction);
        direction = Vector3.ClampMagnitude(direction, 1);
        anim.SetFloat("Horizontal", direction.x * speed);
        anim.SetFloat("Vertical", direction.z * speed);
    }

    public void Dash()
    {
        // teleport the distance, Dash!
        tf.position += (rb.velocity * dashDistance);
    }

    public void AddHealth(float healthToAdd)
    {
         playerHP.SetHealth(healthToAdd);
    }

    public void EquipWeapon(Weapon gun)
    {
        if (weapon != null)
        {
            UnEquipWeapon();
        }

        weapon = gun;
        // try out different instantiates
        GameManager.instance.equippedWeapon = Instantiate(gun) as Weapon;
        GameManager.instance.equippedWeapon.transform.SetParent(attachmentPoint);
        GameManager.instance.equippedWeapon.transform.localPosition = gun.transform.localPosition;
        GameManager.instance.equippedWeapon.transform.localRotation = gun.transform.localRotation;
        // change the layer
        GameManager.instance.equippedWeapon.gameObject.layer = gameObject.layer;
        // add events
        OnTriggerPull.AddListener(GameManager.instance.equippedWeapon.OnPullTrigger);
        OnTriggerRelease.AddListener(GameManager.instance.equippedWeapon.OnReleaseTrigger);
    }

    public void UnEquipWeapon()
    {
        OnTriggerPull.RemoveListener(GameManager.instance.equippedWeapon.OnPullTrigger);
        OnTriggerRelease.RemoveListener(GameManager.instance.equippedWeapon.OnReleaseTrigger);
        Destroy(GameManager.instance.equippedWeapon.gameObject);
        weapon = null;
    }
}
