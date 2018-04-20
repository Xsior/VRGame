using Framework.References;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public float destroyTimeout = 0.1f;
    public IntReference score;
    private ParticleSystem particles;

    private Collider col;

    private void OnCollisionEnter (Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hand")) {
            return;
        }

        //Instantiate(particles, transform.position, Quaternion.identity);
        particles.Play();
        GetComponent<MeshRenderer>().enabled = false;
        col.enabled = false;
        Destroy(gameObject, destroyTimeout);

        score.Value += 1;
    }

    private void Awake ()
    {
        col = GetComponent<Collider>();
        particles = GetComponent<ParticleSystem>();
    }
}
