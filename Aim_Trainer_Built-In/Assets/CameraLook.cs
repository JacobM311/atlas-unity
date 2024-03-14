using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float Sensitivity = 10f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    public PlayerSettings playerSettings;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("movement");
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;

        xRotation += mouseX * playerSettings.sens;
        yRotation -= mouseY * playerSettings.sens;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }
}