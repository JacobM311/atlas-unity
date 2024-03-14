using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetection : MonoBehaviour
{
    AudioSource m_AudioSource;

    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];

    public delegate void BeatDetectedHandler();
    public static event BeatDetectedHandler OnSeventhBandBeatDetected;

    public float seventhBandThreshold = 100.0f;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        CheckForSeventhBandBeat();
    }

    void CheckForSeventhBandBeat()
    {
        // Check if the seventh band's value crosses the threshold
        if (_freqBand[0] > seventhBandThreshold)
        {
            // Trigger the event
            OnSeventhBandBeatDetected?.Invoke();
        }
    }

    void GetSpectrumAudioSource()
    {
        m_AudioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }

            average /= count;

            _freqBand[i] = average * 10;
        }
    }
}
