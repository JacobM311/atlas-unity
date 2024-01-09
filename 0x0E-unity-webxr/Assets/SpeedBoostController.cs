using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostController : MonoBehaviour
{
    public float force = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "Interactable")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }
    }
}
