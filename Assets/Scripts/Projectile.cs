using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float      damageRadius;
    public float      damageForse;
    [HideInInspector] public float      forse;
    public GameObject effect;
    public GameObject ball;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * forse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        ball.SetActive(false);
        effect.SetActive(true);
        CheckHit();
        Destroy(gameObject, 1f);
    }

    public void CheckHit()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemys)
        {
            float dist = Vector3.Distance(gameObject.transform.position, enemy.transform.position);

            if(dist < damageRadius)
            {
                float pureDamage = (dist * damageForse) / damageRadius;
                enemy.GetComponent<HealthCopmponent>().LowedHealth(gameObject.transform, pureDamage);
            }
        }
    }
}
