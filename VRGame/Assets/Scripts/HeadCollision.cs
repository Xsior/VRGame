using Framework;
using Framework.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollision : MonoBehaviour
{
    public LayerMask collisionLayer;
    public GameEvent onPlayerFailed;

    private void OnCollisionEnter (Collision collision)
    {
        if (collisionLayer.ContainsLayer(collision.gameObject.layer))
        {
            onPlayerFailed.Raise();
        }
    }
}
