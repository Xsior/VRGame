using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirectionTest : MonoBehaviour
{
    private void Update ()
    {
        transform.RotateAround(transform.position, Vector3.right, 15 * Time.deltaTime);
    }
}
