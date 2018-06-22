using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour, IHitListener {

    public HazardGenerator hazardGenerator;
    public List<GameObject> gameObjectToDisable;

    public void OnHit(Collision collision)
    {
        hazardGenerator.enabled = true;
        foreach(GameObject g in gameObjectToDisable)
        {
            g.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
