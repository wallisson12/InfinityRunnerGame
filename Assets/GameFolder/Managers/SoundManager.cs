using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    [Header("BackGround")]
    [SerializeField] private AudioSource sound_Bg;
    [SerializeField] private AudioClip[] clips_Bg;

    [Header("Effects")]
    [SerializeField] private AudioSource sound_Efx;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(inst);
        }
        else
        {
            Destroy(gameObject);
        }    
    }


    void Update()
    {
        //if (!sound_Bg.isPlaying)
        //{
        //    sound_Bg.clip = RandomClip();
        //    sound_Bg.Play();
        //}
    }

    AudioClip RandomClip()
    {
        return clips_Bg[Random.Range(0,clips_Bg.Length)];
    }

    public void PlayAudio(AudioClip clip,float volume,float pitch)
    {
        sound_Efx.pitch = pitch;
        sound_Efx.PlayOneShot(clip,volume);
    }
}
