using Framework.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollision : MonoBehaviour
{
    public GameEvent onPlayerFailed;

    private void OnCollisionEnter (Collision collision)
    {
        onPlayerFailed.Raise();    
    }
}
