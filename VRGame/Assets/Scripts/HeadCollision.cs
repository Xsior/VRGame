using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollision : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
