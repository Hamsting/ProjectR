using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    [SerializeField]
    private int bar = 0;
    [SerializeField]
    private float beat = 0.0f;
    [SerializeField]
    private float bpm = 60.0f;
    [SerializeField]
    private float originalBPM = 60.0f;
    [SerializeField]
    private float beatPerSecond = 60.0f / 60.0f * GlobalDefines.BeatPerBar;
    
    public float CurrentBPM
    {
        get
        {
            return bpm;
        }
        set
        {
            bpm = value;
            OnBPMChanged();
        }
    }

    public float OriginalBPM
    {
        get
        {
            return originalBPM;
        }
    }


    
    private void Awake()
    {
    }

    private void Start()
    {
        originalBPM = bpm;
    }

    private void Update()
    {
        UpdateBarAndBeat();
        
    }

    private void UpdateBarAndBeat()
    {
        beat += beatPerSecond * Time.deltaTime;
        if (beat >= GlobalDefines.BeatPerBar)
        {
            beat -= (float)GlobalDefines.BeatPerBar;
            ++bar;
        }
    }

    private void OnBPMChanged()
    {
        beatPerSecond = bpm / 60.0f * GlobalDefines.BeatPerBar;
    }

    public void OnChangeBPMButtonPressed(float _bpm)
    {
        CurrentBPM = _bpm;
    }
}
