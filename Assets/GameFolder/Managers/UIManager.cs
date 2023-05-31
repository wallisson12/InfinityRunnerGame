using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    [SerializeField] private CanvasGroup gameOverScreen,startGameScreen;


    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
    }

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

        Time.timeScale = 0f;
    }
}
