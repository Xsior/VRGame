using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackWallCollision : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<CubeCollision>() == null) {
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
