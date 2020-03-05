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
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform rightHandPoint;
    [SerializeField] private Transform rightElbowPoint;
    [SerializeField] private Transform leftHandPoint;
    [SerializeField] private Transform leftElbowPoint;
    [SerializeField] [Range(0.0f, 1.0f)] private float IKweight;

    // events
    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerHP = GetComponent<PlayerHealth>();
        EquipWeapon(weapon);

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
        playerHP.Heal(healthToAdd);
    }

    public void EquipWeapon(Weapon gun)
    {
        if (weapon != null)
        {
            UnEquipWeapon();
        }

        weapon = gun;
        // try out different instantiates
        weapon = Instantiate(gun) as Weapon;
        weapon.transform.SetParent(attachmentPoint);
        weapon.transform.localPosition = gun.transform.localPosition;
        weapon.transform.localRotation = gun.transform.localRotation;
        // change the layer
        weapon.gameObject.layer = gameObject.layer;
        // add events
        OnTriggerPull.AddListener(weapon.OnPullTrigger);
        OnTriggerRelease.AddListener(weapon.OnReleaseTrigger);


        //// try out different instantiates
        //GameManager.instance.equippedWeapon = Instantiate(gun) as Weapon;
        //GameManager.instance.equippedWeapon.transform.SetParent(attachmentPoint);
        //GameManager.instance.equippedWeapon.transform.localPosition = gun.transform.localPosition;
        //GameManager.instance.equippedWeapon.transform.localRotation = gun.transform.localRotation;
        //// change the layer
        //GameManager.instance.equippedWeapon.gameObject.layer = gameObject.layer;
        //// add events
        //OnTriggerPull.AddListener(GameManager.instance.equippedWeapon.OnPullTrigger);
        //OnTriggerRelease.AddListener(GameManager.instance.equippedWeapon.OnReleaseTrigger);
    }

    public void UnEquipWeapon()
    {
        OnTriggerPull.RemoveListener(weapon.OnPullTrigger);
        OnTriggerRelease.RemoveListener(weapon.OnReleaseTrigger);
        //GameManager.instance.equippedWeapon = null;
        Destroy(weapon.gameObject);
        weapon = null;
    }

    void OnAnimatorIK()
    {
        if (!weapon)
        {
            return;
        }
        if (weapon.rightHand)
        {
            rightHandPoint = weapon.rightHand;
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKweight);
            anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowPoint.position);
            anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, IKweight);
            
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
        }
        
        if(weapon.leftHand)
        {
            leftHandPoint = weapon.leftHand;
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKweight);
            anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowPoint.position);
            anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, IKweight);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
}
