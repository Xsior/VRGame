using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using Framework.References;

public class ScoreboardManager : MonoBehaviour
{
    public Text scoreText;
    

    public IntReference score;

    
    

    void Start ()
    {
       
        score.Value = 0;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            score.Value += 1;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            
           
        }

        scoreText.text = score.Value.ToString()+"X";

       
    }
    

    

}
