using Framework.Events;
using Framework.References;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public string collisionTag;
    public float destroyTimeout = 0.1f;
    public IntReference score;
    private ParticleSystem particles;

    public GameEvent onBlockCollision;

    private Collider col;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (!collision.gameObject.CompareTag(collisionTag)) {
            return;
        }
        Debug.Log("With hand");

        var grabbing = collision.gameObject.GetComponent<Grabbing>();
        grabbing?.HapticPulse();

        //Instantiate(particles, transform.position, Quaternion.identity);
        particles.Play();
        foreach(MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
        {
            m.enabled = false;
        }
        //GetComponent<MeshRenderer>().enabled = false;
        col.enabled = false;
        Destroy(gameObject, destroyTimeout);

        score.Value += 1;

        onBlockCollision.Raise();
    }

    private void Awake ()
    {
        col = GetComponent<Collider>();
        particles = GetComponent<ParticleSystem>();
    }
}
