using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
    public Vector3 velocity;

    private Rigidbody rb;

    private void Start ()
    {
        rb.velocity = velocity;
    }

    private void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }
}
