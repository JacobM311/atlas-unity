using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleyController : MonoBehaviour
{
    public GameObject[] obstacles;
    private List<GameObject> knockedOverPins = new List<GameObject>();
    private bool coroutineRunning = false;
    private int BallResets = 0;

    private void Update()
    {
        if (BallResets == 2)
        {
            BallResets = 0;
            if (knockedOverPins != null)
            {
                ResetAllPins();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            ActivateObstacles();
        }
    }

    public void ResetObstacles()
    {
        foreach (var obstacle in obstacles)
        {
            obstacle.SetActive(false);
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

    public void RemovePin(GameObject pin)
    {
        if (!knockedOverPins.Contains(pin))
        {
            knockedOverPins.Add(pin);
        }

        if (!coroutineRunning)
        {
            StartCoroutine(DisablePinsAfterDelay(4f));
        }
    }

    private IEnumerator DisablePinsAfterDelay(float delay)
    {
        coroutineRunning = true;
        yield return new WaitForSeconds(delay);

        foreach (GameObject pin in knockedOverPins)
        {
            pin.SetActive(false);
        }
        coroutineRunning = false;
    }

    private void ResetAllPins()
    {
        foreach(GameObject pin in knockedOverPins)
        {
            PinScript pinScript = pin.GetComponentInParent<PinScript>();

            if (pinScript != null)
            {
                pinScript.ResetPins();
            }
        }
        knockedOverPins.Clear();
    }

    public void ResetsIterator()
    {
        BallResets++;
        Debug.Log(BallResets);
    }


}
