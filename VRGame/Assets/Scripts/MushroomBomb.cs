﻿using Framework.Events;
using UnityEngine;

public class MushroomBomb : MonoBehaviour, IHitListener
{
    public GameEvent playerDeadEvent;

    public void OnHit(Collision other)
    {
        Debug.Log("!!!");
        if (GetComponent<ParticleSystem>())
            GetComponent<ParticleSystem>().Play();
        playerDeadEvent.Raise();
    }
}
