using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    [Header("Screens")]
    [SerializeField] private CanvasGroup gameOverScreen,startGameScreen,pauseScreen;

    [Header("Hud")]
    public TextMeshProUGUI distanceTxt,distanceHud;
    public Image shooterBar;

    //--Buttons--
    private Button playBtn, retryBtn, pauseBtn,backPauseBtn,rankBtn, menuBtn;
    

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }

        Load();
    }

    /// <summary>
    /// Take all buttons and add methods
    /// </summary>
    void Load()
    {

        //Screens

        startGameScreen = GameObject.FindGameObjectWithTag("StartGameScreen").GetComponent<CanvasGroup>();
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen").GetComponent<CanvasGroup>();
        pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen").GetComponent<CanvasGroup>();



        //Buttons


        //Pause
        pauseBtn = GameObject.FindGameObjectWithTag("PauseBtn").GetComponent<Button>();
        backPauseBtn = GameObject.FindGameObjectWithTag("ReturnPause").GetComponent<Button>();


        //GameOver
        retryBtn = GameObject.FindGameObjectWithTag("RestartBtn").GetComponent<Button>();


        //Events
        pauseBtn.onClick.AddListener(PauseGame);
        backPauseBtn.onClick.AddListener(BackPause);
        retryBtn.onClick.AddListener(Retry);

    }



    //---Buttons Methods---
    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }







    //---Screens methods---

    /// <summary>
    /// Start the game
    /// </summary>
    public void StartGame()
    {
        startGameScreen.alpha = 0f;
        startGameScreen.interactable = false;
        startGameScreen.blocksRaycasts = false;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Enable the game over screen
    /// </summary>
    public void GameOver()
    {
        gameOverScreen.alpha = 1f;
        gameOverScreen.interactable = true;
        gameOverScreen.blocksRaycasts = true;
    }

    public void PauseGame()
    {
        pauseScreen.alpha = 1f;
        pauseScreen.interactable = true;
        pauseScreen.blocksRaycasts = true;
        Time.timeScale = 0f;
    }

    public void BackPause()
    {
        pauseScreen.alpha = 0f;
        pauseScreen.interactable = false;
        pauseScreen.blocksRaycasts = false;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Manage the shooter bar
    /// </summary>
    public void ManagerShooterBar(PlayerController p)
    {
        shooterBar.fillAmount = p.timeBullet;
    }
}
