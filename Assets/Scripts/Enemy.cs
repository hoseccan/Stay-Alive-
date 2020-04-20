using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private GameObject   target;
    public  Animator     animator;
    private NavMeshAgent agent;

    private float        distToTarget;
    public  float        distToAttack;
    public  float        damage;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent  = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distToTarget = Vector3.Distance(target.transform.position, gameObject.transform.position);
        agent.SetDestination(target.transform.position);

        if(agent.speed != 0)
        {
            agent.isStopped = false;
            animator.SetBool("IsRun", true);
            animator.SetBool("IsAttack", false);
        }

        if (distToTarget < distToAttack)
        {
            transform.LookAt(new Vector3(target.transform.position.x,0, target.transform.position.z));
            agent.isStopped = true;
            animator.SetBool("IsRun", false);
            animator.SetBool("IsAttack", true);
        }
    }

    public void Attack()
    {
        if (distToAttack > distToTarget)
        {
            target.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
