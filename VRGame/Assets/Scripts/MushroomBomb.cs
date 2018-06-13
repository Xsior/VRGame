using Framework.Events;
using UnityEngine;

public class MushroomBomb : UnityEngine.MonoBehaviour, IHitListener
{
    public GameEvent playerDeadEvent;

    public void OnHit(Collision other)
    {
        playerDeadEvent.Raise();
    }
}
