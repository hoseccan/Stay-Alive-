using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float forseOfShoot;

    private Animator   animator;
    public  Transform  fierPoint;
    public  GameObject projectile;
    public  GameObject effects;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("MouseDown", true);
        }
        else
        {
            animator.SetBool("MouseDown", false);
        }
    }

    public void Shoot()
    {
        effects.SetActive(true);
        GameObject bull = Instantiate(projectile, fierPoint.position,Quaternion.identity);
        bull.transform.rotation = fierPoint.transform.rotation;
        bull.GetComponent<Projectile>().forse = forseOfShoot;
    }

    public void Repet()
    {
        effects.SetActive(false);
    }
}
