using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRagdollSystem : MonoBehaviour
{
    public Collider[]  colliders;
    public Rigidbody[] rigidbodys;

    public Enemy        Enm;
    public Animator     Anim;
    public NavMeshAgent Ag;

    void Start()
    {
        GetAllRigidbodyAndColliders();
    }

    public void GetAllRigidbodyAndColliders()
    {
        colliders = GetComponentsInChildren<Collider>();
        rigidbodys = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rig in rigidbodys)
        {
            rig.isKinematic = true;
        }
    }

    public void DeathCondition()
    {
        foreach (Rigidbody rig in rigidbodys)
        {
            rig.isKinematic = false;
            rig.useGravity = true;
        }

        Enm.enabled  = false;
        Anim.enabled = false;
        Ag.enabled   = false;
    }
}
