using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = Random.Range(-.5f, .5f);
        transform.position = currentPosition;
    }
}
