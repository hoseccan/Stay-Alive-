using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    public AudioSource sourse;
    public Enemy       mainScrept;

    public void Footsteps()
    {
        sourse.Play();
    }

    public void Attack()
    {
        mainScrept.Attack();
    }
}
