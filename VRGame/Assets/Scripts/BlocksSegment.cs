using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSegment : MonoBehaviour
{

    //public Vector3 speed = new Vector3(0, 0, -6);
    public float length = 0;
    private List<ConstantVelocity> blocksSpeed;


    public void setSpeed(Vector3 speed)
    {
        foreach(ConstantVelocity c in blocksSpeed)
        {
            c.velocity = speed; 
        }
    }

    void Awake()
    {
        Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
            blocksSpeed.Add(transform.GetChild(i).gameObject.GetComponent<ConstantVelocity>());
    }

}
