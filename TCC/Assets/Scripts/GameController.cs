using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int senaRestart;
    public int senaNext;
    public int scenaMenu;
    public static GameController instance;
    public int score;
    public GameObject pauseObj;
    private bool isPaused;
    public GameObject gameOverObj;
    public GameObject fimFaseObj;
    public GameObject barraDeVida;
    public Slider barraBoss;
    public Text scoreText;
    public GameObject fim;
    
    
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
    
    
    void Update()
    {
        PauseGame();
    }

    public void BarraDeVida()
    {
        barraDeVida.SetActive(true);
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
            
            if (isPaused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        
    }

    public void GameOver()
    {
        Debug.Log("marreu");
        Time.timeScale = 0f;
        gameOverObj.SetActive(true);
        
    }

    public void FimDeFase()
    {
        Time.timeScale = 0f;
        fimFaseObj.SetActive(true);
    }
    public void NextGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(senaNext);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(senaRestart);
    }

    public void VoltarParaMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scenaMenu);
    }
    
}
