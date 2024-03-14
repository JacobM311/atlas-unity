using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Slider sensSlider;
    public Image reticle;
    public PlayerSettings playerSettings;
    private bool pressed = false;
    public CameraLook camera1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pressed)
        {
            pressed = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            sensSlider.gameObject.SetActive(true);
            reticle.gameObject.SetActive(false);
            camera1.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pressed)
        {
            playerSettings.sens = sensSlider.value;
            pressed = false;
            Cursor.lockState= CursorLockMode.Locked;
            Cursor.visible = false;
            sensSlider.gameObject.SetActive(false);
            reticle.gameObject.SetActive(true);
            camera1.enabled = true;
        }
    }
}
