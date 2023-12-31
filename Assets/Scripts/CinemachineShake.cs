using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    public float shakeTimer;
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnPerfectTiming, OnPerfectTiming);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnPerfectTiming, OnPerfectTiming);
    }

    //Camera shake voidi
    public void OnPerfectTiming(object intensityVal, object timeVal)
    {
        float intensity = (float)intensityVal;
        float time = (float)timeVal;

        cinemachineBasicMultiChannelPerlin =
                     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    void Update()
    {
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                cinemachineBasicMultiChannelPerlin =
                     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}