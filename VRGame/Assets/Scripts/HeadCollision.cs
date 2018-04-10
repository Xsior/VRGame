using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject);
    }
}
