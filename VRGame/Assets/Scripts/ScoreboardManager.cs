using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using Framework.References;

public class ScoreboardManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;

    public IntReference score;

    private int numblocks = 0;
    private float startTime;
    float t;

    void Start ()
    {
        startTime = Time.time;
        score.Value = 0;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            AddBlock();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            ResetBlocks();
            ResetTime();
        }

        scoreText.text = score.Value.ToString();

        timeText.text = StarTime();
    }
    public void AddBlock ()
    {
        numblocks += 1;
    }

    public void ResetBlocks()
    {
        numblocks = 0;
    }

    public string StarTime ()
    {
        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
        ;
    }
    public void ResetTime ()
    {
        t = 0;
        startTime = 0;
    }

}
