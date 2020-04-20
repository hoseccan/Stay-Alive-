using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelUnit[] levels;
    public int levelIndex = 0;
    public int score;
    public GameObject winScreen;

    public GameObject InfoScreen;

    void Start()
    {
        InitializeLevel(levelIndex);
    }

    public void InitializeLevel(int Index)
    {
        levels[Index].SetUpLevel();
        score = levels[Index].spawnPoint.Length;
    }

    public void UpdateScore()
    {
        score--;

        if (score == 0)
        {
            GameObject[] deads = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject dead in deads)
            {
                Destroy(dead);
            }
            levelIndex++;
            if (levelIndex == levels.Length)
            {
                winScreen.SetActive(true);
                return;
            }
            StartCoroutine(LoadLevel());
        }
    }

    public IEnumerator LoadLevel()
    {
        InfoScreen.SetActive(true);
           yield return new WaitForSeconds(2f);
        InitializeLevel(levelIndex);
        InfoScreen.SetActive(false);
    } 
}
