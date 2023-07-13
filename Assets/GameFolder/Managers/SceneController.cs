using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Button playMenu, rankMenu;
    
    public void LoadScene(int n)
    {
        //To Make Transition scene
        SceneManager.LoadScene(n);
    }

    /// <summary>
    /// Open rankscreen of menu
    /// </summary>
    public void OpenRankMenu(CanvasGroup rankScreenn)
    {
        rankScreenn.alpha = 1f;
        rankScreenn.interactable = true;
        rankScreenn.blocksRaycasts = true;

        playMenu.interactable = false;
        rankMenu.interactable = false;
    }

    /// <summary>
    /// Close rankscreen of menu
    /// </summary>
    public void CloseRankMenu(CanvasGroup rankScreenn)
    {
        rankScreenn.alpha = 0f;
        rankScreenn.interactable = false;
        rankScreenn.blocksRaycasts = false;

        playMenu.interactable = true;
        rankMenu.interactable = true;
    }
}
