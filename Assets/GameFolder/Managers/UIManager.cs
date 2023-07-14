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
    [SerializeField] private CanvasGroup gameOverScreen,pauseScreen,rankScreen;

    [Header("Hud")]
    public TextMeshProUGUI distanceTxt,distanceHud;
    public Image shooterBar;

    //--Buttons--
    private Button shootBtn, jumpBtn;
    private Button retryGameOverBtn,menuGameOverBtn, pauseBtn,backPauseBtn,menuPauseBtn,rankPauseBtn,closePauseRank;


    [Header("SoundEfx")]
    [SerializeField] private AudioClip buttonPress_Efx;
    [SerializeField] private float volume,pitch;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }

        SceneManager.sceneLoaded += Load;
    }

    /// <summary>
    /// Take all buttons and add methods
    /// </summary>
    void Load(Scene cena, LoadSceneMode mode)
    {
        //--Hud--

        shootBtn = GameObject.FindGameObjectWithTag("ShootBtn").GetComponent<Button>();
        jumpBtn = GameObject.FindGameObjectWithTag("JumpBtn").GetComponent<Button>();

        //--Screens--

        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen").GetComponent<CanvasGroup>();
        pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen").GetComponent<CanvasGroup>();
        rankScreen = GameObject.FindGameObjectWithTag("RankScreen").GetComponent<CanvasGroup>();


        //--Buttons--


        //Pause
        pauseBtn = GameObject.FindGameObjectWithTag("PauseBtn").GetComponent<Button>();
        backPauseBtn = GameObject.FindGameObjectWithTag("ReturnPause").GetComponent<Button>();
        menuPauseBtn = GameObject.FindGameObjectWithTag("MenuPause").GetComponent<Button>();
        rankPauseBtn = GameObject.FindGameObjectWithTag("RankingBtn").GetComponent<Button>();
        closePauseRank = GameObject.FindGameObjectWithTag("ClosePauseRank").GetComponent<Button>();

        //GameOver
        retryGameOverBtn = GameObject.FindGameObjectWithTag("RestartBtn").GetComponent<Button>();
        menuGameOverBtn = GameObject.FindGameObjectWithTag("MenuGameOver").GetComponent<Button>();


        //--Events--

        //Pause
        pauseBtn.onClick.AddListener(PauseGame);
        backPauseBtn.onClick.AddListener(BackPause);
        menuPauseBtn.onClick.AddListener(Menu);
        rankPauseBtn.onClick.AddListener(Rank);
        closePauseRank.onClick.AddListener(CloseRank);

        //GameOver
        retryGameOverBtn.onClick.AddListener(Retry);
        menuGameOverBtn.onClick.AddListener(Menu);

    }



    //---Buttons Methods---
    void Retry()
    {
        SoundManager.inst.PlayAudio(buttonPress_Efx, volume,pitch);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Menu()
    {
        SoundManager.inst.PlayAudio(buttonPress_Efx, volume, pitch);

        //Mudar depois quando trocar o menu
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    void CloseRank()
    {
        SoundManager.inst.PlayAudio(buttonPress_Efx, volume, pitch);

        rankScreen.alpha = 0f;
        rankScreen.interactable = false;
        rankScreen.blocksRaycasts = false;
    }


    //---Screens methods---

    /// <summary>
    /// Enable the game over screen
    /// </summary>
    public void GameOver()
    {
        gameOverScreen.alpha = 1f;
        gameOverScreen.interactable = true;
        gameOverScreen.blocksRaycasts = true;
    }

    public void Rank()
    {
        SoundManager.inst.PlayAudio(buttonPress_Efx, volume, pitch);

        rankScreen.alpha = 1f;
        rankScreen.interactable = true;
        rankScreen.blocksRaycasts = true;
    }

    public void PauseGame()
    {
        SoundManager.inst.PlayAudio(buttonPress_Efx, volume, pitch);

        pauseScreen.alpha = 1f;
        pauseScreen.interactable = true;
        pauseScreen.blocksRaycasts = true;
        Time.timeScale = 0f;

        //Disable hud
        shootBtn.interactable = false;
        jumpBtn.interactable = false;
    }


    public void BackPause()
    {
        SoundManager.inst.PlayAudio(buttonPress_Efx, volume, pitch);

        pauseScreen.alpha = 0f;
        pauseScreen.interactable = false;
        pauseScreen.blocksRaycasts = false;
        Time.timeScale = 1f;

        //Enable hud
        shootBtn.interactable = true;
        jumpBtn.interactable = true;
    }

    /// <summary>
    /// Manage the shooter bar
    /// </summary>
    public void ManagerShooterBar(PlayerController p)
    {
        shooterBar.fillAmount = p.timeBullet;
    }
}
