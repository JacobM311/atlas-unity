using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleyController : MonoBehaviour
{
    public GameObject[] obstacles;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            ActivateObstacles();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.SetActive(false);
            }
        }
    }

    void ActivateObstacles()
    {
        foreach (GameObject obstacle in obstacles)
        {
            int i = Random.Range(0, 2);

            if (i == 1)
            {
                obstacle.SetActive(true);
            }

            ObstacleController oc = obstacle.GetComponent<ObstacleController>();
            if (oc != null)
            {
                oc.Activate();
            }
        }
    }
}
