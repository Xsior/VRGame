﻿using Framework.Events;
using UnityEngine;
using System.Collections.Generic;

public class BackWallCollision : MonoBehaviour
{
    public GameEvent onPlayerFailed;
    private int hp = 3;
    private List<Rigidbody> children = new List<Rigidbody>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CubeCollision>() == null)
        {
            return;
        }
        hp--;
        if (hp <= 0)
        {
            BrakeWall();
            onPlayerFailed.Raise();
        }
    }

    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            children.Add(transform.GetChild(i).gameObject.GetComponent<Rigidbody>());
    }


    void BrakeWall()
    {
        foreach (Rigidbody c in children)
        {
            c.isKinematic = false;
            c.gameObject.GetComponent<Collider>().isTrigger = false;
            //c.AddForce(new Vector3(0, 0, 50));
            c.AddExplosionForce(3000, new Vector3(13, 0.2f, 0), 0);
        }
    }
}
