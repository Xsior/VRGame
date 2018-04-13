using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    public void Scale (float scale)
    {
        Time.timeScale = scale;
    }

    public void StopTime ()
    {
        Scale(0);
    }

    public void LaunchTime ()
    {
        Scale(1);
    }

    private void Start ()
    {
        LaunchTime();
    }
}
