using Framework.Events;
using UnityEngine;

public class BackWallCollision : MonoBehaviour
{
    public GameEvent onPlayerFailed;

    private void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<CubeCollision>() == null) {
            return;
        }

        onPlayerFailed.Raise();
    }
}
