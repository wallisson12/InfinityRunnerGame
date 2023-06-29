using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCam : MonoBehaviour
{
    public static ShakeCam Instance;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private CinemachineBasicMultiChannelPerlin cbmp;

    private float shakeTimer;
    private float startingShakeTime;
    private float startingIn;

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
            cbmp.m_NoiseProfile = profileType.noise;
            cbmp.m_AmplitudeGain = profileType.amplitude;
            cbmp.m_FrequencyGain = profileType.frequency;

            shakeTimer = profileType.duration;
            startingShakeTime = profileType.duration;
            startingIn = profileType.amplitude;
        }
    }

    /// <summary>
    /// Stop shaking hard
    /// </summary>
    void StopShake()
    {

        cbmp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (cbmp != null)
        {
            cbmp.m_AmplitudeGain = 0f;
            cbmp.m_FrequencyGain = 0f;
        }
    }

    void Update()
    {
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {

                //Stop shaking more soft
                cbmp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cbmp.m_AmplitudeGain = Mathf.Lerp(startingIn,0f,1 - (shakeTimer/startingShakeTime) );
                cbmp.m_FrequencyGain = 0f;

            }

        }
    }
    


}
