using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 Position = transform.localPosition;
            Position.z += Time.deltaTime * speed;

            transform.localPosition = Position;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 Position = transform.localPosition;
            Position.z -= Time.deltaTime * speed;

            transform.localPosition = Position;
        }
    }
}