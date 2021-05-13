using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void StartGame()
    {
        ScoreManager.instance.StartScore();
        UIManager.instance.GameStart();
        PlatformSpawner.instance.StartSpawning();
    }

    public void EndGame()
    {
            ScoreManager.instance.StopScore();
            UIManager.instance.GameOver();
    }
}