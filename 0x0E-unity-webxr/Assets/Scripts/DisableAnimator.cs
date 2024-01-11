using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimator : MonoBehaviour
{
    public BallController[] BallController;

    public void DisableAnim()
    {
        foreach (var b in BallController)
        {
            b.DisableAnimator();
        }
    }
}
