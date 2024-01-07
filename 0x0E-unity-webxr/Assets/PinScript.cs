using UnityEngine;

public class PinScript : MonoBehaviour
{
    private Quaternion initialRotation;
    public float thresholdAngle = 10f;
    private bool isKnockedOver;
    public ScoreManager scoreManager;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (!isKnockedOver)
        {
            float angleDifference = Quaternion.Angle(transform.rotation, initialRotation);

            if (angleDifference > thresholdAngle)
            {
                isKnockedOver = true;

                scoreManager.IncreaseScore();
            }
        }
    }
}