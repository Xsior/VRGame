using System.Security.Permissions;
using Framework.References;
using UnityEngine;

[System.Serializable]
public class Spawner
{
    [Header("Prefabs")] 
    public GameObject block;
    public BlocksSegment[] segments;
    public GameObject[] walls;
    
    [Header("Values")]
    public FloatReference currentSpeed;
    public FloatReference spawningDistance;
    public FloatReference wallSpawnHeight;
    
    [Space]
    
    public Transform vrHead;

    public Transform Parent { get; set; }

    private float PlayerHeight => Mathf.Clamp(vrHead.position.y, 1.2f, 2f);
    
    public GameObject SpawnWall()
    {
        int r = Random.Range(0, walls.Length);
        GameObject wallInstance = Object.Instantiate(walls[r], Vector3.zero, Parent.rotation, Parent);
        
        wallInstance.transform.localPosition = new Vector3(0, wallSpawnHeight, spawningDistance);
        wallInstance.GetComponent<ConstantVelocity>().velocity = new Vector3(0, 0, -currentSpeed);
        
        return wallInstance;
    }

    public GameObject SpawnHazard()
    {
        float rX = Random.Range(-0.6f, 0.6f);
        float rY = Random.Range(PlayerHeight - 0.6f, PlayerHeight + 0.4f);

        var blockInstance = Object.Instantiate(block, Vector3.zero, Parent.rotation, Parent);
        var blockVelocity = blockInstance.GetComponent<ConstantVelocity>();
        blockInstance.transform.localPosition = new Vector3(rX, rY, spawningDistance);
        blockVelocity.velocity = new Vector3(0, 0, -currentSpeed);
        
        return blockInstance;
    }

    public BlocksSegment SpawnSegment()
    {
        var r = Random.Range(0, segments.Length);

        BlocksSegment segmentInstance = Object.Instantiate(segments[r], Vector3.zero, Parent.rotation, Parent);
        segmentInstance.transform.localPosition = new Vector3(0, PlayerHeight - 0.2f, spawningDistance);
        segmentInstance.Velocity = new Vector3(0, 0, -currentSpeed);

        return segmentInstance;
    }
}