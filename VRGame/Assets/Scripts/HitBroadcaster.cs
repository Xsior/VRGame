    using UnityEngine;
    using UnityEngine.EventSystems;

public class HitBroadcaster : MonoBehaviour
    {
        public string collisionTag;

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(collisionTag)) {
                return;
            }

            ExecuteEvents.Execute<IHitListener>(gameObject, null, (handler, data) => handler.OnHit(other));
        }
    }
