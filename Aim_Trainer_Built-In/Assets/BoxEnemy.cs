using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : MonoBehaviour
{
    public List<GameObject> boxes;
    private int maxAttempts = 100;
    public AudioSource hitSound;
    public float _startScale, _scaleMulitplier;
    
    public int _band;
    public float _maxScale = 2f; // The max scale of the box based on the frequency
    public float _lerpTime = 0.001f;

    private float _currentScale;

    private void Awake()
    {
        BeatDetection.OnSeventhBandBeatDetected += HandleSeventhBandBeat;
        _currentScale = _startScale;
        ResetPosition();
    }

    void HandleSeventhBandBeat()
    {
        // Respond to the beat, e.g., by changing the color of an object
        Debug.Log("Seventh band beat detected!");
        // Implement your response to the beat here
    }

    void Update()
    {
        float targetScale = Mathf.Lerp(_startScale, _maxScale, BeatDetection._freqBand[_band] / 1);
        _currentScale = Mathf.Lerp(_currentScale, targetScale, _lerpTime * Time.deltaTime);
        transform.localScale = new Vector3((BeatDetection._freqBand[_band] * _scaleMulitplier) + _startScale, (BeatDetection._freqBand[_band] * _scaleMulitplier) + _startScale, (BeatDetection._freqBand[_band] * _scaleMulitplier) + _startScale);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        bool positionFound = false;

        for (int attempts = 0; attempts < maxAttempts; attempts++)
        {
            Vector3 position = new Vector3(Random.Range(-9, 9), Random.Range(-8, 8), transform.position.z);

            bool isValidPosition = true;
            foreach (var box in boxes)
            {
                if (box == gameObject) continue;

                float distanceToBox = Vector3.Distance(position, box.transform.position);
                if (distanceToBox < 2f)
                {
                    isValidPosition = false;
                    break;
                }
            }

            if (isValidPosition)
            {
                transform.position = position;
                hitSound.Play();
                positionFound = true;
                break;
            }
        }
    }
}
