using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocomotion : MonoBehaviour {

    public float speed = 0.4f;

    Vector3 lastPos = Vector3.zero;

    void Update()
    {
        //The headset initializes at Vector3.zero, and remains there during Start(), so initialize lastPos here
        if (lastPos == Vector3.zero) lastPos = transform.position;
        var offset = transform.position - lastPos;
        offset.y = 0;
        transform.parent.position += offset * speed;
        lastPos = transform.position;
    }
}
