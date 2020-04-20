using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelkomeScreen : MonoBehaviour
{
    public void Start()
    {
        Invoke("CloseScreen", 3f);
    }
    private void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}
