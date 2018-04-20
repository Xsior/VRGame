using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSegment : MonoBehaviour
{

    //public Vector3 speed = new Vector3(0, 0, -6);
    public float length = 0;

    public ConstantVelocity itemPrefab;

    private List<ConstantVelocity> blocksSpeed = new List<ConstantVelocity>();

    public float getLength ()
    {
        if (blocksSpeed.Count <= 0)
            return 0;

        Vector3 minPos = blocksSpeed[0].transform.localPosition;
        Vector3 maxPos = blocksSpeed[0].transform.localPosition;

        foreach (ConstantVelocity c in blocksSpeed) {
            if (c.transform.localPosition.z < minPos.z)
                minPos = c.transform.localPosition;
            if (c.transform.localPosition.z > maxPos.z)
                maxPos = c.transform.localPosition;
        }
        float distance = maxPos.z - minPos.z;
        return distance;
    }

    public void setSpeed (Vector3 speed)
    {
        foreach (ConstantVelocity c in blocksSpeed) {
            c.velocity = speed;
        }
    }

    private void SpawnCubes ()
    {
        foreach (Transform child in transform) {
            var itemInstance = Instantiate(itemPrefab, child, false);
            itemInstance.transform.localPosition = Vector3.zero;

            blocksSpeed.Add(itemInstance);
        }
    }

    private void Start ()
    {
        SpawnCubes();
    }
}
