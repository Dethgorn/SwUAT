using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIK : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Transform rightHandPoint;
    [SerializeField]
    private Transform rightElbowPoint;
    [SerializeField]
    private Transform leftHandPoint;
    [SerializeField]
    private Transform leftElbowPoint;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float IKweight;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        leftHandPoint = GameManager.instance.equippedWeapon.leftHand;
        rightHandPoint = GameManager.instance.equippedWeapon.rightHand;
    }

    
    protected virtual void OnAnimatorIK()
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPoint.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKweight);
        anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowPoint.position);
        anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, IKweight);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPoint.position);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKweight);
        anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowPoint.position);
        anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, IKweight);

    }
    
}
