using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnit : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[]  spawnPoint;

    public void SetUpLevel()
    {
        foreach(Transform point in spawnPoint)
        {
            int rand = Random.Range(0, enemys.Length);
            Instantiate(enemys[rand],point.transform);
        }
    }
}
