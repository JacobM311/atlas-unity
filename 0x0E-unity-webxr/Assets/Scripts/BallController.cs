using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force = .5f;
    private Rigidbody rb;
    private bool onTrack = false;
    private bool isReset = false;
    private Vector3 startingPoint;
    private List<GameObject> obstacles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (onTrack)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * force);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * force);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Reset")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = startingPoint;
            onTrack = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BallThrown")
        {
            onTrack = true;
        }
    }
}
