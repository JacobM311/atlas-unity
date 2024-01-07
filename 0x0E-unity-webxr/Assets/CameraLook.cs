using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float Sensitivity = 10f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRotation += mouseX;
        yRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);

    }
}
