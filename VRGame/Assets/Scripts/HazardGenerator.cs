﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public List<GameObject> walls;
    public List<GameObject> blocks;
    public GameObject block;
    public Camera VrHead;

    //This is never used. Remove?
    [HideInInspector] public float TimeToNext = 3.5f;

    [Header("Spawning info")]
    public float startSpeed = 7;
    public float speedIncrease = 0.01f;
    public float spawningDistance = 35;
    public float PlayerHeight = 1.7f;
    public float wallSpawnHeight = 2.196f;
    public float distanceBetweenSegments = 4;


    [Header("Timing")]
    public float distanceBetweenRandomBlocks = 3f;
    public float distanceBetweenWalls = 5f;
    public int blocksBeforeTheWall = 7;

    private float currentSpeed;
    private float timer = 2;
    private float timePassed;
    private float toNextWall;

    private void GenerateBlock ()
    {
        int r = Random.Range(0, blocks.Count + 1);
        if (r == blocks.Count) {
            GenerateRandomBlock();
            return;
        }
        GameObject g = Instantiate(blocks[r], Vector3.zero, transform.rotation, transform);
        BlocksSegment b = g.GetComponent<BlocksSegment>();
        g.transform.localPosition = new Vector3(0, PlayerHeight - 0.2f, spawningDistance);
        b.Velocity = new Vector3(0, 0, -currentSpeed);

        var length = Mathf.Approximately(b.length, 0f) ? b.getLength() : b.length;

        timer = (length + distanceBetweenSegments) / currentSpeed;
        toNextWall--;
        if (toNextWall <= 0) {
            timer += 1.5f;
        }
    }

    private void GenerateRandomBlock ()
    {
        float rX = Random.Range(-0.6f, 0.6f);
        float rY = Random.Range(PlayerHeight - 0.6f, PlayerHeight + 0.4f);

        var blockInstance = Instantiate(block, Vector3.zero, transform.rotation, transform);
        var blockVelocity = blockInstance.GetComponent<ConstantVelocity>();
        blockInstance.transform.localPosition = new Vector3(rX, rY, spawningDistance);
        blockVelocity.velocity = new Vector3(0, 0, -currentSpeed);
        timer = distanceBetweenRandomBlocks / currentSpeed;
        toNextWall--;
        if (toNextWall <= 0) {
            timer += 1.5f;
        }
    }

    private void GenerateWall ()
    {
        int r = Random.Range(0, walls.Count);
        GameObject g = Instantiate(walls[r], Vector3.zero, transform.rotation, transform);
        g.transform.localPosition = new Vector3(0, wallSpawnHeight, spawningDistance);
        g.GetComponent<ConstantVelocity>().velocity = new Vector3(0, 0, -currentSpeed);
        timer = distanceBetweenWalls / currentSpeed;
    }

    void Start ()
    {
        currentSpeed = startSpeed;
        toNextWall = blocksBeforeTheWall;
        PlayerHeight = VrHead.transform.position.y;
        if (PlayerHeight < 1.2f)
            PlayerHeight = 1.2f;
        else if (PlayerHeight > 2f)
            PlayerHeight = 2f;

    }

    void FixedUpdate ()
    {
        timePassed += Time.fixedDeltaTime;

        if (timer > 0) {
            timer -= Time.fixedDeltaTime;
        } else {

            if (toNextWall <= 0) {
                toNextWall = blocksBeforeTheWall;
                GenerateWall();
            } else {
                GenerateBlock();
            }

            currentSpeed += speedIncrease;
            //if (TimeToNext > 1.5f)
            //    TimeToNext -= 0.02f;
        }
    }
}
