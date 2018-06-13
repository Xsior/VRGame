using Framework.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatermelonOnHitEvent : MonoBehaviour, IHitListener {

    public GameEvent onWatermelonHit;

    public void OnHit(Collision collision)
    {
        onWatermelonHit.Raise();
    }


}
