using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCam : MonoBehaviour
{
    public static ShakeCam Instance;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private CinemachineBasicMultiChannelPerlin cbmp;
    //private float shakeAmount = 3f;
    //private float shakeFrequency = 40f;
    //private float shakeDuration = .3f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        cam = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        StopShake();
    }

    public void TriggerShake(TypeShake profileType)
    {
        cbmp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (cbmp != null)
        {
            cbmp.m_AmplitudeGain = profileType.amplitude;
            cbmp.m_FrequencyGain = profileType.frequency;
            Invoke("StopShake", profileType.duration);
        }
    }

    void StopShake()
    {
        cbmp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (cbmp != null)
        {
            cbmp.m_AmplitudeGain = 0f;
            cbmp.m_FrequencyGain = 0f;
        }
    }


}
