using Framework.Events;
using UnityEngine;
using System.Collections.Generic;

public class BackWallCollision : MonoBehaviour
{
    public GameEvent onPlayerFailed;
    public int hp = 9;
    private List<Rigidbody> children = new List<Rigidbody>();
    private int slicesPerHP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CubeCollision>() == null)
        {
            return;
        }
        hp--;
        BrakeWall();
        if (hp <= 0)
        {
            onPlayerFailed.Raise();
        }
    }

    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            children.Add(transform.GetChild(i).gameObject.GetComponent<Rigidbody>());
        slicesPerHP = Mathf.FloorToInt( children.Count / hp);

    }


    void BrakeWall()
    {
        if (children.Count == 0)
            return;
        if (children.Count < slicesPerHP)
        {
            slicesPerHP = children.Count;
        }
        for(int i =0; i < slicesPerHP; i++)
        {
            children[i].isKinematic = false;
            children[i].AddForce(new Vector3(-800,500, 0));
            Destroy(children[i], 3f);
            children.RemoveAt(i);
            
        }
        foreach (Rigidbody c in children)
        {
            //c.isKinematic = false;
            //c.gameObject.GetComponent<Collider>().isTrigger = false;
            //c.AddForce(new Vector3(0, 5, 50));
            //c.AddExplosionForce(3000, new Vector3(13, 0.2f, 0), 0);
        }
    }
}
