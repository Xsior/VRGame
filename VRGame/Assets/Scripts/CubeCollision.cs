using Framework.Events;
using Framework.References;
using UnityEngine;

public class CubeCollision : MonoBehaviour, IHitListener
{
    public float destroyTimeout = 0.1f;
    public IntReference score;
    private ParticleSystem particles;

    public GameEvent onBlockCollision;

    private Collider col;

    public void OnHit(Collision collision)
    {
        var grabbing = collision.gameObject.GetComponent<Grabbing>();
        grabbing?.HapticPulse();

        //Instantiate(particles, transform.position, Quaternion.identity);
//        particles.Play();
//        foreach(MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
//        {
//            m.enabled = false;
//        }
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
