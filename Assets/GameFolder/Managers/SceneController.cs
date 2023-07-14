using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Button playMenu, rankMenu;
    [SerializeField] private AudioClip menuClip;
    [SerializeField] private float volume,pitch;
    
    public void LoadScene(int n)
    {
        //Audio
        SoundManager.inst.PlayAudio(menuClip, volume,pitch);

        //To Make Transition scene
        SceneManager.LoadScene(n);
    }

    /// <summary>
    /// Open rankscreen of menu
    /// </summary>
    public void OpenRankMenu(CanvasGroup rankScreenn)
    {

        //Audio
        SoundManager.inst.PlayAudio(menuClip, volume, pitch);

        //Screen
        rankScreenn.alpha = 1f;
        rankScreenn.interactable = true;
        rankScreenn.blocksRaycasts = true;

        //Button
        playMenu.interactable = false;
        rankMenu.interactable = false;
    }

    /// <summary>
    /// Close rankscreen of menu
    /// </summary>
    public void CloseRankMenu(CanvasGroup rankScreenn)
    {
        //Audio
        SoundManager.inst.PlayAudio(menuClip, volume, pitch);

        //Screen
        rankScreenn.alpha = 0f;
        rankScreenn.interactable = false;
        rankScreenn.blocksRaycasts = false;

        //Button
        playMenu.interactable = true;
        rankMenu.interactable = true;
    }
}
