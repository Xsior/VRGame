using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public float destroyTimeout = 1f;

    private Collider col;

    private void OnCollisionEnter (Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hand")) {
            return;
        }

        col.enabled = false;
        Destroy(gameObject, destroyTimeout);
    }

    private void Awake ()
    {
        col = GetComponent<Collider>();
    }
}
