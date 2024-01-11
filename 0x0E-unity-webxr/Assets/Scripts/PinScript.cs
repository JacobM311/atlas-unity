using UnityEngine;

public class PinScript : MonoBehaviour
{
    private Quaternion initialRotation;
    public float thresholdAngle = 10f;
    private bool isKnockedOver;
    public ScoreManager scoreManager;
    public AlleyController alleyController;
    private Vector3 initialPosition;
    public GameObject Pin;

    void Start()
    {
        initialRotation = Pin.transform.rotation;
        initialPosition = Pin.transform.position;
    }

    void Update()
    {
        if (!isKnockedOver)
        {
            float angleDifference = Quaternion.Angle(Pin.transform.rotation, initialRotation);

            if (angleDifference > thresholdAngle)
            {
                isKnockedOver = true;

                scoreManager.IncreaseScore();

                alleyController.RemovePin(Pin);
            }
        }
    }

    public void ResetPins()
    {
        Pin.SetActive(true);
        Pin.transform.position = initialPosition;
        Pin.transform.rotation = initialRotation;
        Rigidbody rb = Pin.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isKnockedOver = false;
    }
}