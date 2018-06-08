using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    public Vector3 axis = Vector3.up;
    
    public bool randomizeAxis;

    private float anglePerSecond;

    private void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);

        if (randomizeAxis) {
            RandomizeAxis();    
        }
    }

    private float time;
    
    private void RandomizeAxis()
    {
        time = Mathf.Repeat(time + Time.deltaTime, 1f);
        var tt = 1 - time;
        
        axis.x = time * tt;
        axis.z = time * time * tt * tt;
        axis.y = Mathf.Lerp(axis.x, axis.y, time);
    }
}
