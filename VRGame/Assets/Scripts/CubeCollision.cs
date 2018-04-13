using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public float destroyTimeout = 1f;
    public ParticleSystem particles;

    private Collider col;

    private void OnCollisionEnter (Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hand")) {
            return;
        }

        Destroy(gameObject);
        Instantiate(particles, transform.position, Quaternion.identity);
    }

    private void Awake ()
    {
        col = GetComponent<Collider>();
    }
}
