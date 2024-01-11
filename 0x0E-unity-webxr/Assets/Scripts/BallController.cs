using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public float force = .5f;
    private float boostForce = 10.0f;
    private Rigidbody rb;
    private bool onTrack = false;
    private Vector3 startingPoint;
    public Animator animator;
    public AlleyController alleyController;
    public Collider resetArea;


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
            alleyController.ResetsIterator();
            resetArea.enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = startingPoint;
            onTrack = false;
            alleyController.ResetObstacles();
            resetArea.enabled = true;
            Debug.Log("reset area reset");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BallThrown")
        {
            animator.enabled = true;
            animator.SetTrigger("OnTrack");
            onTrack = true;
        }

        if (other.gameObject.tag == "Boost")
        {
            rb.AddForce(Vector3.forward * boostForce);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BallThrown")
        {
            resetArea.enabled = false;
            Debug.Log("trigger exit reset");
            StartCoroutine(InitialReset(3.5f));
        }
    }

    private IEnumerator InitialReset(float delay)
    {
        if (onTrack)
        {
            onTrack = false;
            yield return new WaitForSeconds(delay);
            ResetBall();
        }
    }

    private void ResetBall()
    {
        resetArea.enabled = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startingPoint;
        alleyController.ResetsIterator();
        alleyController.ResetObstacles();
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
    }
}