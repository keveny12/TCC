using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int score;
    public GameObject pauseObj;
    private bool isPaused;
    public GameObject gameOverObj;
    public GameObject fimFaseObj;

    public Text scoreText;
  
    void Start()
    {
        instance = this;
        isPaused = false;
        
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
       
        
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverObj.SetActive(true);
    }

    public void FimDeFase()
    {
        fimFaseObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void VoltarParaMenu()
    {
        SceneManager.LoadScene(0);
    }
}
