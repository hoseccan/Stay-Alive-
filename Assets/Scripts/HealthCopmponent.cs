using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealthCopmponent : MonoBehaviour
{
    public float health;
    public bool  alreadyDeath = false;
    public EnemyRagdollSystem ragDoll;

    public void LowedHealth(Transform hitLocation, float dismiss)
    {
        //print("Damage is " + dismiss);
        health -= dismiss;

        if (health < 1)
        {
            FindClosestRagPoint(hitLocation);
        }
    }

    private void FindClosestRagPoint(Transform hitLocation)
    {
        Collider[]                  colliders   = ragDoll.colliders;
        List<float>                 keys        = new List<float>();
        Dictionary<float, Collider> dict        = new Dictionary<float, Collider>();

        foreach(Collider coll in colliders)
        {
            float dist = Vector3.Distance(hitLocation.position, coll.GetComponentInParent<Transform>().position);
            dict.Add(dist, coll);
            keys.Add(dist);
        }
        float clearestPointKey = keys.Min();
        Collider contactedColl = dict[clearestPointKey];

        FindNormal(hitLocation, contactedColl);
    }

    private void FindNormal(Transform hitLocation, Collider coll)
    {
        Vector3 forseNormal = (hitLocation.position - coll.GetComponentInParent<Transform>().position);
        ragDoll.DeathCondition();
        coll.attachedRigidbody.AddForce(forseNormal * 1000f);

        if (!alreadyDeath)
        {
            FindObjectOfType<LevelController>().UpdateScore();
            alreadyDeath = true;
        }
    }
}
