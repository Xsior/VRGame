using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public List<GameObject> walls;
    public List<GameObject> blocks;
    public GameObject block;
    public bool started = true;
    public float TimeToNext = 3.5f;
    public float startSpeed = 5;
    public float distanceBetweenSegmentsd = 5;

    private float currentSpeed = 5;
    private float timer = 2;
    private float toNextWall = 3;

    private void generateBlock()
    {
        int r = Random.Range(0, blocks.Count+1);
        if(r == blocks.Count)
        {
            GenerateRandomBlock();
            return;
        }
        GameObject g = Instantiate(blocks[r], Vector3.zero, transform.rotation, transform);
        BlocksSegment b = g.GetComponent<BlocksSegment>();
        g.transform.localPosition = new Vector3(0, 1.3f, 35);
        b.setSpeed(new Vector3(0, 0, -currentSpeed));
        float length;
        if (b.length == 0)
        {
            length = b.getLength();
        }
        else
        {
            length = b.length;
        }
        Debug.Log(length);
        timer = (length + distanceBetweenSegmentsd) / currentSpeed;
        toNextWall--;
        if (toNextWall <= 0)
        {
            timer += 1.5f;
        }
    }
    void GenerateRandomBlock()
    {
        float rX = Random.Range(-0.6f, 0.6f);
        float rY = Random.Range(0.7f, 2f);

        GameObject g = Instantiate(block, Vector3.zero, transform.rotation, transform);
        BlocksSegment b = g.GetComponent<BlocksSegment>();
        g.transform.localPosition = new Vector3(rX,rY, 35);
        b.setSpeed(new Vector3(0, 0, -currentSpeed));
        timer = 2.3f / currentSpeed;
        toNextWall--;
        if (toNextWall <= 0)
        {
            timer += 1.5f;
        }
    }

    private void generatWall()
    {
        int r = Random.Range(0, walls.Count);
        GameObject g = Instantiate(walls[r], Vector3.zero, transform.rotation, transform);
        g.transform.localPosition = new Vector3(0, 2.196f, 35);
        g.GetComponent<ConstantVelocity>().velocity = new Vector3(0, 0, -currentSpeed);
        timer = 5f / currentSpeed;
        
    }

    void Start()
    {
        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (started)
        {
            if (timer > 0)
            {
                timer -= Time.fixedDeltaTime;
            }
            else {
                if (toNextWall <= 0) {
                    toNextWall = 7;
                    generatWall();
                } else {
                generateBlock();
                 }
                
                currentSpeed += 0.05f;
                if (TimeToNext > 1.5f)
                    TimeToNext -= 0.02f;
            }
        }
    }
}
