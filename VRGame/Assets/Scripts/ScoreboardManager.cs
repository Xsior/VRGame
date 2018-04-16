using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class ScoreboardManager : MonoBehaviour {
    public Text scoreText;
    public Text timeText;
    private int numblocks=0;
    private float startTime;
    float t;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            addBlock();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            resetBlocks();
            resetTime();
        }

            scoreText.text = numblocks.ToString();
        
        timeText.text = starTime();
	}
    public void addBlock() {
        numblocks += 1;
    }
    public void resetBlocks() { numblocks = 0; }
    public string starTime() {
         t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds; ;
    }
    public void resetTime() {
        t = 0;
        startTime = 0;
    }

}
