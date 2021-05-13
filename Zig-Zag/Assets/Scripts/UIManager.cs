using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text tapText;
    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public Text highScoreTitle;
    public Text score;
    public Text highScoreEnd;

    public static UIManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        highScoreTitle.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
       
        tapText.gameObject.SetActive(false);
        titlePanel.GetComponent<Animator>().SetBool("gameStarted", true);
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScoreEnd.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().SetBool("gameEnded", true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
