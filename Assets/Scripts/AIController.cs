using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public CharacterPawn AIpawn;
    private NavMeshAgent agent;
    public Transform target;
    public Animator anim;

    


    private void Awake()
    {
        agent = AIpawn.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //agent.enabled = true;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //player = FindObjectOfType();
        //if (!player)
        //{
        //    navMeshAgent.Stop();
        //    Animator.SetFloat("Horizontal", 0f);
        //    Animator.SetFloat("Vertical", 0f);
        //    return;
        //}

        agent.SetDestination(target.position);

        Vector3 input = agent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        anim.SetFloat("Horizontal", input.x);
        anim.SetFloat("Vertical", input.z);

    }

    private void OnAnimatorMove()
    {
        agent.velocity = anim.velocity;
    }

}
