using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float healthInStart;
    public Image ragePanel;
    public GameObject GameOver;

    public void Update()
    {
        UpdatePanel();

        if (health < healthInStart)
        {
            health = health + 3f * Time.deltaTime;
        }
        if (health <= 0)
        {
            GameOver.SetActive(true);
            StartCoroutine(Exit());
        }
    }

    private void UpdatePanel()
    {
        float init = 1-(health / healthInStart);
        Color c = ragePanel.color;
        c.a = init;
        ragePanel.color = c;
    }

    public IEnumerator Exit()
    {
        yield return new WaitForSeconds(2f);
        print("You are Death");
        Application.Quit();
    }
}
