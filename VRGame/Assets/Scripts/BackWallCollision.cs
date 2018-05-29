using Framework.Events;
using UnityEngine;
using System.Collections.Generic;

public class BackWallCollision : MonoBehaviour
{
    public GameEvent onPlayerFailed;
    public Transform swordIndicator;
    public int hp = 9;
    private List<GameObject> children = new List<GameObject>();
    private List<GameObject> indictaorChildren = new List<GameObject>();
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

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            children.Add(transform.GetChild(i).gameObject);
        for (int i = 0; i < swordIndicator.childCount; i++)
            indictaorChildren.Add(swordIndicator.GetChild(i).gameObject);
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
            children[i].GetComponent<Rigidbody>().isKinematic = false;
            children[i].GetComponent<Rigidbody>().AddForce(new Vector3(-800,300, 0));
            Destroy(children[i], 3f);
            children.RemoveAt(i);
            Destroy(indictaorChildren[i]);
            indictaorChildren.RemoveAt(i);
        }
        //foreach (Rigidbody c in children)
        //{
            //c.isKinematic = false;
            //c.gameObject.GetComponent<Collider>().isTrigger = false;
            //c.AddForce(new Vector3(0, 5, 50));
            //c.AddExplosionForce(3000, new Vector3(13, 0.2f, 0), 0);
        //}
    }
}
