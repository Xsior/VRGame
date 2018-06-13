using UnityEngine;
using UnityEngine.EventSystems;

public interface IHitListener : IEventSystemHandler
{
    void OnHit(Collision collision);
}