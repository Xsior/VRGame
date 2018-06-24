using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public ConstantVelocity itemPrefab;

    public void SpawnCubes(Vector3 Velocity)
    {

        var itemInstance = Instantiate(itemPrefab, transform, false);
        itemInstance.transform.localPosition = Vector3.zero;
        itemInstance.velocity = Velocity;

    }
}
